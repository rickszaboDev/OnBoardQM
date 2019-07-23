namespace OnBoard.Services.Model
{
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
        public string deviceName { get; set; }
        public string deviceModel { get; set; }
        public bool recordPassword { get; set; }
    }
}