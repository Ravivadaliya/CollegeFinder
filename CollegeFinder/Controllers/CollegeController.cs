using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using CollegeFinder.Models;
using System.Net.Mail;
using System.Net;
using CollegeFinder.DAL;
using System.Data;

namespace CollegeFinder.Controllers
{
    public class CollegeController : Controller
    {
        private IConfiguration Configuration;


        public CollegeController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult AllColleges()
        {

            string connstr = Configuration.GetConnectionString("myConnectionStrings");
            Client admindal = new Client();
            DataTable dt = admindal.College_SelectAll(connstr);
            return View("AllColleges", dt);
        }

        public IActionResult Admission()
        {
            return View();
        }

        public IActionResult SingleCollege(int? Collegeid)
        {
            string connstr = Configuration.GetConnectionString("myConnectionStrings");
            Client admindal = new Client();
            DataTable dt = admindal.College_SelectByPk(connstr,Collegeid);
            return View("SingleCollege", dt);
        }

       
    }
}
