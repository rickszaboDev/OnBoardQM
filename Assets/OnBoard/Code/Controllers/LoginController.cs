using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using OnBoard.Services;
using OnBoard.Services.Model;

namespace OnBoard.Controller
{
    public class LoginController : MonoBehaviour
    {
        public TMPro.TMP_InputField username;
        public TMPro.TMP_InputField password;
        public Button submit;

        public Button createNewUser;

        public void SubmitData()
        {
            Login login = new Login
            {
                username = this.username.text,
                password = this.password.text,
                deviceName = "Strontium",
                deviceModel = "StrontiumModel"
            };

            var data = APIService.SetRawData(login);
            APIService.RequestLogon(data, (res) =>
            {
                if (res.StatusCode != 200)
                {
                    //Aviso de "Usuário ou senha inexistente/incorreta."
                    Debug.Log($"Usuário ou senha inexistente/incorreta.{res.StatusCode}");
                }         
            });
        }

        public void CallCreateNewUser()
        {
            ControllerBase.LoadScene("signUpScene");
        }
    }
}