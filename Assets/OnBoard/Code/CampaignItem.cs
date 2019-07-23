using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using OnBoard.Services.Model;

public class CampaignItem : MonoBehaviour
{
    public Campaign myCampaign;
    public TextMeshProUGUI campaign_name;
    public TextMeshProUGUI date_start;
    public TextMeshProUGUI date_end;

    public void Setup(Campaign myCampaign)
    {
        DateTime dateTimeStart;
        DateTime dateTimeEnd;

        this.date_start.text = DateTime.TryParse(myCampaign.dateStart, out dateTimeStart) ? GetDateDescription(dateTimeStart, "Inicio :") : "";
        this.date_end.text = DateTime.TryParse(myCampaign.dateEnd, out dateTimeEnd) ? GetDateDescription(dateTimeEnd, "Fim :") : "";

        this.campaign_name.text = myCampaign.name;
    }

    private string GetDateDescription(DateTime date, string statusText)
    {
        return string.Concat("Data de ", statusText, date.Day.ToString("d2"), "/", date.Month.ToString("d2"));
    }
}
