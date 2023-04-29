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

        public IActionResult Admission(int Collegeid)
        {
            string connstr = Configuration.GetConnectionString("myConnectionStrings");
            Client admindal = new Client();
            DataTable dt = admindal.College_Seatcheck(connstr, Collegeid);

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

            if (college.SearchName == null && college.SearchCity==null)
            {
                TempData["noinput"] = "Search Box Are empty";
                Client cliendal = new Client();
                DataTable dt = cliendal.College_SelectAll(str);
                return View("AllColleges", dt);
            }
            else if(college.SearchCity == null)
            {
                cmd.CommandText = "[CollegesearchByname]";
                cmd.Parameters.Add("@Searchname", SqlDbType.VarChar).Value = college.SearchName;
                DataTable dt = new DataTable();
                SqlDataReader objsdr = cmd.ExecuteReader();
                dt.Load(objsdr);
                return View("AllColleges", dt);
            }
            else if(college.SearchName == null)
            {
                cmd.CommandText = "[CollegesearchByCity]";
                cmd.Parameters.Add("@SearchCity", SqlDbType.VarChar).Value = college.SearchCity;
                DataTable dt = new DataTable();
                SqlDataReader objsdr = cmd.ExecuteReader();
                dt.Load(objsdr);
                return View("AllColleges", dt);

            }
            else
            {  
                cmd.CommandText = "[CollegeSearch]";
                cmd.Parameters.Add("@Searchname", SqlDbType.VarChar).Value = college.SearchName;
                cmd.Parameters.Add("@SearchCity", SqlDbType.VarChar).Value = college.SearchCity;
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
                TempData["Admission"] = "Admission Successfully";
            }
            return View("Admission");
        }


    }
}
