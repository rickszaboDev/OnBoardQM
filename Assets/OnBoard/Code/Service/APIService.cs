using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using BestHTTP;
using Newtonsoft.Json;
using OnBoard.Controller;
using OnBoard.Persistance;

namespace OnBoard.Services
{
    public class APIService : MonoBehaviour
    { 
        public delegate void OnRequestFinishedDelegate(HTTPResponse response);

        //Utils
        public static byte[] SetRawData(object data)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
        }

        //Requests
        //GET
        public static void RequestCheckVersion(string baseURL, string os, string version, OnRequestFinishedDelegate callback)
        {
            HTTPRequest request = new HTTPRequest(new Uri( $"https://api.qmedia.com.br/api/Common/version_check/{os}/{version}"), (req, res) => 
                {
                    if (res.StatusCode == 404)
                    {
                        //Debug.Log("Send to update at store");
                        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Qupix.QMedia");
                    }
                    else if (res.StatusCode == 200)
                    {
                        Debug.Log(version);
                        callback(res);                        
                    }
                });
            request.AddHeader("accept", "text/json");
            request.AddHeader("q-imei", SystemInfo.deviceUniqueIdentifier);
            request.Send();
        }

        public static void RequestUsernameExists(string username, string email, OnRequestFinishedDelegate callback)
        {
            HTTPRequest request = new HTTPRequest(new Uri($"https://dev-api.qmedia.com.br/api/player/exists/username/{username}"), (req, res) =>
            {
                if(res.DataAsText == "false")
                {
                    APIService.RequestEmailExists(email, callback);
                } else
                {
                    Debug.Log("Usuário existente");
                }
            });
            request.AddHeader("accept", "text/json");
            request.AddHeader("q-imei", SystemInfo.deviceUniqueIdentifier);
            request.Send();
        }

        public static void RequestEmailExists(string email, OnRequestFinishedDelegate callback)
        {
            HTTPRequest request = new HTTPRequest(new Uri($"https://dev-api.qmedia.com.br/api/player/exists/email/" + email), (req, res) =>
            {
                if (res.DataAsText == "false")
                {
                    Debug.Log("Permitido criar novo usuário.");
                    callback(res);
                }
                else
                {
                    Debug.Log("Email existente");
                }
            });
            request.AddHeader("accept", "text/json");
            request.AddHeader("q-imei", SystemInfo.deviceUniqueIdentifier);
            request.Send();
        }

        public static void RequestCompanyCampaign(OnRequestFinishedDelegate callback)
        {
            HTTPRequest request = new HTTPRequest(new Uri($"https://dev-api.qmedia.com.br/api/logged/v1/company-campaign"), (req, res) =>
            {
                if(res.StatusCode == 200)
                {
                    callback(res);
                } else
                {
                    Debug.Log("Informar erro.");
                }
            });
            string QToken = Persistance.Persistance.BinaryLoad<string>("q-token");
            request.AddHeader("accept", "text/json");
            request.AddHeader("q-imei", SystemInfo.deviceUniqueIdentifier);
            request.AddHeader("q-token", QToken);
            request.Send();
        }

        //POST
        public static void RequestLogon(byte[] data, OnRequestFinishedDelegate callback)
        {
            HTTPRequest request = new HTTPRequest(new Uri($"https://dev-api.qmedia.com.br/api/player/logon"), HTTPMethods.Post, (req, res) =>
            {
                if(res.StatusCode == 200)
                {
                    Persistance.Persistance.BinarySave("q-token", res.GetHeaderValues("q-token")[0]);
                    ControllerBase.LoadScene("mainScene");
                }
                else
                {
                    Debug.Log("Usuário ou senha inexistente/incorreta.");
                }

                callback(res);
            });
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("accept", "text/json");
            request.AddHeader("q-imei", SystemInfo.deviceUniqueIdentifier);
            request.RawData = data;
            request.Send();
        }

        public static void RequestCreateUser(byte[] data)
        {
            HTTPRequest request = new HTTPRequest(new Uri($"https://dev-api.qmedia.com.br/api/player/create"), HTTPMethods.Post, (req, res) =>
            {
                if (res.StatusCode == 200)
                {
                    Persistance.Persistance.BinarySave("q-token", res.GetHeaderValues("q-token")[0]);
                    ControllerBase.LoadScene("mainScene");
                }
                else
                {
                    Debug.Log($"Ocorreu um erro {res.StatusCode}. Tente novamente mais tarde.");
                }
            });
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("accept", "text/json");
            request.AddHeader("q-imei", SystemInfo.deviceUniqueIdentifier);
            request.RawData = data;
            request.Send();
        }
    }
}