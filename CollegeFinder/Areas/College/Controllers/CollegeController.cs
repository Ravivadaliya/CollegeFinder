using CollegeFinder.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using CollegeFinder.Areas.College.Models;
using CollegeFinder.BAL;
using System.Data.SqlClient;
using CollegeFinder.Areas.CollegeType.Models;
//using System.Configuration;
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

      
        //public IActionResult Map()
        //{
        //    string markers = "[";
        //    string conString = this.Configuration.GetConnectionString("myConnectionStrings");
        //    SqlCommand cmd = new SqlCommand("SELECT * FROM CollegeLatLong");
        //    using (SqlConnection con = new SqlConnection(conString))
        //    {
        //        cmd.Connection = con;
        //        con.Open();
        //        using (SqlDataReader sdr = cmd.ExecuteReader())
        //        {
        //            while (sdr.Read())
        //            {
        //                markers += "{";
        //                markers += string.Format("'title': '{0}',", sdr["College_name"]);
        //                markers += string.Format("'lat': '{0}',", sdr["latitude"]);
        //                markers += string.Format("'lng': '{0}',", sdr["longitude"]);
        //                markers += "},";
        //            }
        //        }
        //        con.Close();
        //    }

        //    markers += "];";
        //    ViewBag.Markers = markers;
        //    return View();

        //}

        public IActionResult Index()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Adminpanel ad = new Adminpanel();
            DataTable dt = ad.College_selectall(connectionstr);
            return View("Index", dt);
        }


        public IActionResult Delete(int? Collegeid)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Adminpanel ad = new Adminpanel();

            if (Convert.ToBoolean(ad.College_Delete(connectionstr, Collegeid)))
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
            Adminpanel ad = new Adminpanel();
            DataTable dt1 = ad.CollegeTypeDropdown(connectionstr);

            List<CollegeTypeDropDownModel> list = new List<CollegeTypeDropDownModel>();

            foreach(DataRow dr in dt1.Rows)
            {
                CollegeTypeDropDownModel vlist = new CollegeTypeDropDownModel();
                vlist.collegetypeid = Convert.ToInt32(dr["collegetypeid"]);
                vlist.collegeType = dr["collegeType"].ToString();
                list.Add(vlist);
            }
            ViewBag.Collegetypelist = list;


            if (Collegeid != null)
            {
                DataTable dt = ad.College_SelectByPk(connectionstr, Collegeid);
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
                        ForCollege.Imagepath = dr["Imagepath"].ToString();
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


            if (Forcollege.File1 != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileNameWithPath = Path.Combine(path, Forcollege.File1.FileName);
                Forcollege.College_image = FilePath.Replace("wwwroot\\", "/") + "/" + Forcollege.File1.FileName;
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    Forcollege.File1.CopyTo(stream);
                }
            }
            if (Forcollege.File2 != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileNameWithPath = Path.Combine(path, Forcollege.File2.FileName);
                Forcollege.Imagepath = FilePath.Replace("wwwroot\\", "/") + "/" + Forcollege.File2.FileName;
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    Forcollege.File2.CopyTo(stream);
                }
            }

            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");


 

            Adminpanel Fordata= new Adminpanel();

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
