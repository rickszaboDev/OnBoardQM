using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using OnBoard.Services.Model;

public class CompanyElement : MonoBehaviour
{
    public TextMeshProUGUI companyNameText;
    public List<GameObject> campaignsView;

    public GameObject campaignPrefab;

    public string companyName;
    public List<Campaign> campaigns { get; set; }

    public void Setup(string companyName, List<Campaign> campaigns)
    {
        this.companyName = companyName;
        this.campaigns = campaigns;

        companyNameText.text = this.companyName;

        for (int i = 0; i < campaigns.Count; i++) {
            GameObject camp_itm = Instantiate(campaignPrefab) as GameObject;
            camp_itm.transform.parent = gameObject.transform;
            camp_itm.GetComponent<CampaignItem>().Setup(campaigns[i]);

            campaignsView.Add(camp_itm);
        }
    }
}