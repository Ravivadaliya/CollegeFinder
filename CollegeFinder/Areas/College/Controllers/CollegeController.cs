using CollegeFinder.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using CollegeFinder.Areas.College.Models;
using CollegeFinder.BAL;
using System.Data.SqlClient;
using System.Configuration;
namespace CollegeFinder.Areas.College.Controllers
{
    [CheckAccess]
    [Area("College")]
    [Route("College/[controller]/[action]")]
    public class CollegeController : Controller
    {
        private IConfiguration Configuration;


        public CollegeController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Map()
        {
            string markers = "[";
            string conString = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlCommand cmd = new SqlCommand("SELECT * FROM CollegeLatLong");
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
            return View();

        }

        public IActionResult Index()
        {

            string markers = "[";
            string conString = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlCommand cmd = new SqlCommand("select * FROM CollegeLatLong");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        markers += "{";
                        markers += string.Format("'title': '{0}',", sdr["College_Name"]);
                        markers += string.Format("'lat': '{0}',", sdr["latitude"]);
                        markers += string.Format("'lng': '{0}',", sdr["longitude"]);
                        markers += "},";
                    }
                }
                con.Close();
            }

            markers += "];";
            ViewBag.Markers = markers;



            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            AllData dalLOC = new AllData();
            DataTable dt = dalLOC.College_selectall(connectionstr);
            return View("Index", dt);
        }



        public IActionResult Delete(int? Collegeid)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            AllData dalLOC = new AllData();

            if (Convert.ToBoolean(dalLOC.College_Delete(connectionstr, Collegeid)))
                TempData["AlertMsg"] = "Record Delete Successfully";
            else
            {
                TempData["AlertMsg"] = "Not deleted";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Add(int? Collegeid)
        {

            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            AllData dalLOC = new AllData();

            if (Collegeid != null)
            {
                DataTable dt = dalLOC.College_SelectByPk(connectionstr, Collegeid);
                if (dt.Rows.Count > 0)
                {
                    CollegeModel ForCollege = new CollegeModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ForCollege.Collegeid = Convert.ToInt32(dr["Collegeid"]);
                        ForCollege.College_Name = dr["College_Name"].ToString();
                        ForCollege.Genders_Accepted = dr["Genders_Accepted"].ToString();
                        ForCollege.Campus_Size= dr["Campus_Size"].ToString();
                        ForCollege.Total_Student_Enrollments = dr["Total_Student_Enrollments"].ToString();
                        ForCollege.Total_Faculty = dr["Total_Faculty"].ToString();
                        ForCollege.Established_Year = dr["Established_Year"].ToString();
                        ForCollege.Rating = dr["Rating"].ToString();
                        ForCollege.University = dr["University"].ToString();
                        ForCollege.Courses = dr["Courses"].ToString();
                        ForCollege.Facilities = dr["Facilities"].ToString();
                        ForCollege.City = dr["City"].ToString();
                        ForCollege.State = dr["State"].ToString();
                        ForCollege.Country = dr["Country"].ToString();
                        ForCollege.College_Type = dr["College_Type"].ToString();
                        ForCollege.Average_Fees = dr["Average_Fees"].ToString();
                        ForCollege.Placement =Convert.ToInt32(dr["Placement"]);
                        ForCollege.College_area = Convert.ToInt32(dr["College_area"]);
                        ForCollege.Placement= Convert.ToInt32(dr["Placement"]);
                        ForCollege.Totalseat = Convert.ToInt32(dr["Totalseat"]);
                        ForCollege.latitude = dr["latitude"].ToString();
                        ForCollege.longitude = dr["longitude"].ToString();
                        ForCollege.College_image = dr["College_image"].ToString();
                        ForCollege.College_Website = dr["College_Website"].ToString();
                        ForCollege.College_Number = dr["College_Number"].ToString();
                        ForCollege.iframemap = dr["iframemap"].ToString();
                        ForCollege.iframeheight = dr["iframeheight"].ToString();
                        ForCollege.iframewidth = dr["iframewidth"].ToString();

                    }
                    return View("CollegeAddEdit", ForCollege);
                }
            }
            return View("CollegeAddEdit");
        }

        public IActionResult CollegeAddEdit()
        {
            return View();

        }

        public IActionResult Save(CollegeModel Forcollege)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");

            //if (modelHMS_Room.File1 != null)
            //{
            //    string FilePath = "wwwroot\\Upload";
            //    string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

            //    if (!Directory.Exists(path))
            //        Directory.CreateDirectory(path);

            //    string fileNamewithPath = Path.Combine(path, modelHMS_Room.File1.FileName);
            //    modelHMS_Room.RoomPhoto = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelHMS_Room.File1.FileName;

            //    using (var stream = new FileStream(fileNamewithPath, FileMode.Create))
            //    {
            //        modelHMS_Room.File1.CopyTo(stream);
            //    }
            //}



            AllData Fordata= new AllData();

            if (Forcollege.Collegeid==null)
            {

                if (Convert.ToBoolean(Fordata.College_Insert(connectionstr,Forcollege)))
                {
                    TempData["AlertMsg"] = "Record Inserted Successfully";
                }
            }
            else
            {
                if (Convert.ToBoolean(Fordata.College_Update(connectionstr, Forcollege)))
                    TempData["AlertMsg"] = "Record Update Successfully";
            }


            return RedirectToAction("Index");
        }
    }
}
