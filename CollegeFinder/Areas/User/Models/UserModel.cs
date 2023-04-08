namespace CollegeFinder.Areas.User.Models
{
    public class UserModel
    {
        public int? userid { get; set; }
        public string usename { get; set; }
        public string usermobile { get; set; }
        public string usermailid { get; set; }
        public string usercity { get; set; }
        public string userstate { get; set; }
        public string usercountry { get; set; }
        public string userpassword { get; set; }
        public DateTime creationdate { get; set; }
        public DateTime modificationdate { get; set; }
    }
}
