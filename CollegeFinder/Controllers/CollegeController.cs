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
            Client cliendal = new Client();
            DataTable dt = cliendal.College_SelectAll(connstr);
            return View("AllColleges", dt);
        }

        public IActionResult Admission(int? Collegeid)
        {
            TempData["Collegeid"] = Collegeid;
            return View();
        }

        public IActionResult SingleCollege(int? Collegeid)
        {
            string connstr = Configuration.GetConnectionString("myConnectionStrings");
            Client admindal = new Client();
            DataTable dt = admindal.College_SelectByPk(connstr, Collegeid);
            return View("SingleCollege", dt);
        }

        public IActionResult Search(CollegeModel college)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlConnection conn2 = new SqlConnection(str);
            conn2.Open();
            SqlCommand cmd = conn2.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            if (college.Searchname == null)
            {
                Client cliendal = new Client();
                DataTable dt = cliendal.College_SelectAll(str);
                return View("AllColleges", dt);
            }
            else
            {
                cmd.CommandText = "[CollegeSearch]";
                cmd.Parameters.Add("@Searchname", SqlDbType.VarChar).Value = college.Searchname;
                DataTable dt = new DataTable();
                SqlDataReader objsdr = cmd.ExecuteReader();
                dt.Load(objsdr);
                return View("AllColleges", dt);
            }
        }

        public IActionResult TakeAdmission(AdmissionModel admission)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Client Fordata = new Client();

            if (Convert.ToBoolean(Fordata.Student_Insert(connectionstr, admission)))
            {
                TempData["AlertMsg"] = "Admission Successfully";
            }


            return RedirectToAction("SingleCollege");
        }


    }
}
