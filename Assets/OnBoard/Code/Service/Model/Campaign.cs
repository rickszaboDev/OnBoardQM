using System;

namespace OnBoard.Services.Model
{
    public class Campaign
    {
        public int id { get; set; }
        public int companyId { get; set; }
        public int companyIdImageVersion { get; set; }
        public string name { get; set; }
        public int imageVersion { get; set; }
        public int revision { get; set; }
        public string dateStart { get; set; }
        public string dateEnd { get; set; }
    }
}