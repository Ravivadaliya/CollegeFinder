using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CollegeFinder.Areas.Admin.Models
{
    public class AdminModel
    {
        public int? Adminid { get; set; }

        public string Adminname { get; set; }

        public string AdminEmail { get; set; }

        public string Adminpassword { get; set; }

        public string AdminMobil { get; set; }

        public string AdminCity { get; set; }

        public string AdminState { get; set; }

        public string AdminCountry { get; set; }

        public DateTime AdminCreationdate { get; set; }

        public DateTime AdminModificationdate { get; set; }
    }


}
