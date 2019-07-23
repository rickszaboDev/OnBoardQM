using System.Collections.Generic;

namespace OnBoard.Services.Model
{
    public class CompanyCampaign
    {
        public string Username { get; set; }
        public List<Company> Companies { get; set; }
    }

    public class Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public int imageVersion { get; set; }
        public List<Campaign> campaigns { get; set; }
    }
}