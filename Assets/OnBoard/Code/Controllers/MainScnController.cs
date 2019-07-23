using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

using OnBoard.Services;
using OnBoard.Services.Model;

public class MainScnController : MonoBehaviour
{
    public Transform ViewTransf;

    public GameObject companyCardPrefab;

    void Start()
    {
        APIService.RequestCompanyCampaign((res) =>
        {
            var jsonResponse = JsonConvert.DeserializeObject<List<Company>>(res.DataAsText);
            CompanyElement _company;

            for(int i = 0; i < jsonResponse.Count; i++)
            {
                _company = (Instantiate(companyCardPrefab) as GameObject).GetComponent<CompanyElement>();
                _company.transform.parent = ViewTransf;
                var companyName = jsonResponse[i].name;
                var campaigns = jsonResponse[i].campaigns;
                _company.Setup(companyName, campaigns);
            }

            Debug.Log(jsonResponse);
        }); 
    }
}
