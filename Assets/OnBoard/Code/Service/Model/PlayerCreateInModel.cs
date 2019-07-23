using System;

namespace OnBoard.Services.Model
{
    public class PlayerCreateInModel
    {
        public string preuser { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public string full_name { get; set; }

        public long? uniqId { get; set; }

        public DateTime? birthdate { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string mobile_ddd_number { get; set; }

        public string mobile_number { get; set; }
        public string zipcode { get; set; }

        public string address { get; set; }
        public string address_number { get; set; }
        public string adjunct { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }
}
