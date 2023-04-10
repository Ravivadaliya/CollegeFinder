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
    public class CoursesController : Controller
    {
        private IConfiguration Configuration;


        public CoursesController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult AllCourses()
        {
            return View();
        }




        public IActionResult SingleCourse()
        {
            string markers = "[";
            string conString = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlCommand cmd = new SqlCommand("select * from CollegeLatLong");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        markers += "{";
                        markers += string.Format("'title': '{0}',", sdr["College_name"]);
                        markers += string.Format("'lat': '{0}',", sdr["latitude"]);
                        markers += string.Format("'lng': '{0}',", sdr["longitude"]);
                        markers += "},";
                    }
                }
                con.Close();
            }

            markers += "];";
            ViewBag.Markers = markers;

            string connstr = Configuration.GetConnectionString("myConnectionStrings");
            Client admindal = new Client();
            DataTable dt = admindal.College_SelectAll(connstr);
            return View("SingleCourse", dt);

        }

       
    }
}
