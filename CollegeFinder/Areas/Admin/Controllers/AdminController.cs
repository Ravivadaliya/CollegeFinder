using Microsoft.AspNetCore.Mvc;
using CollegeFinder.Areas.Admin.Models;
using CollegeFinder.DAL;
using System.Data;
using CollegeFinder.BAL;
using CollegeFinder.Areas.College.Models;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;   
using System.Configuration;
namespace CollegeFinder.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminController : Controller
    {
        private IConfiguration Configuration;

        public AdminController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult AdminIndex()
        {
            return View();
        }
        public IActionResult SubLogin()
        {
            return View();
        }

        public IActionResult AdminAddEdit()
        {
            return View();
        }
        public IActionResult AllAdmin()
        {
            string connstr = Configuration.GetConnectionString("myConnectionStrings");
            Admindal admindal = new Admindal();
            DataTable dt = admindal.Admin_SelectAll(connstr);
            return View("AllAdmin",dt);
        }
        public IActionResult CheckSubLogin(SubAdminModel subAdmin)
        {
            string error = null;
            
            if (subAdmin.SubAdminEmail != null && subAdmin.SubAdminPassword!= null)
            {
                if (subAdmin.SubAdminEmail == @CV.Adminemail() && subAdmin.SubAdminPassword== @CV.Adminpassword())
                {
                    if (subAdmin.Statusid == 0)
                    {
                      return RedirectToAction("AllAdmin");
                    }
                   else if(subAdmin.Statusid == 1)
                    {
                        return RedirectToAction("AdminAddEdit"); 
                    }
                    else
                    {
                        error = "Enter valid Status id";
                        TempData["Sublogerror"] = error;
                        return RedirectToAction("SubLogin");
                    }
                }
                else
                {
                    error = "Enter Valid Details";
                    TempData["Sublogerror"] = error;
                    return RedirectToAction("SubLogin");
                }
            }
            else
            {
                error = "Email Or Password Are Empty";
                TempData["Sublogerror"] = error;
                return RedirectToAction("SubLogin");
            }
        }
        public IActionResult Dashboard()
        {
            string markers = "[";
            string conString = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlDatabase sqlDB = new SqlDatabase(conString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("[selectalllatlang]");

            DataTable dt = new DataTable();
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                while (dr.Read())
                {
                    markers += "{";
                    markers += string.Format("'title': '{0}',", dr["College_Name"]);
                    markers += string.Format("'lat': '{0}',", dr["latitude"]);
                    markers += string.Format("'lng': '{0}',", dr["longitude"]);
                    markers += "},";
                }
            }

            markers += "];";
            ViewBag.Markers = markers;




            //SqlCommand cmd = new SqlCommand("SELECT * FROM ");
            //using (SqlConnection con = new SqlConnection(conString))
            //{
            //    cmd.Connection = con;
            //    con.Open();
            //    using (SqlDataReader sdr = cmd.ExecuteReader())
            //    {
            //        while (sdr.Read())
            //        {
            //            markers += "{";
            //            markers += string.Format("'title': '{0}',", sdr["College_Name"]);
            //            markers += string.Format("'lat': '{0}',", sdr["latitude"]);
            //            markers += string.Format("'lng': '{0}',", sdr["longitude"]);
            //            markers += "},";
            //        } 
            //    }     
            //    con.Close();
            //}

            //markers += "];";
            //ViewBag.Markers = markers;

            return View();
        }

        [HttpPost]
        public IActionResult Login(AdminModel adminModel)
        {
            string connstr = Configuration.GetConnectionString("myConnectionStrings");
            string error = null;

            if (adminModel.AdminEmail == null)
            {
                error += "Enter Emailid";
            }
            if (adminModel.Adminpassword == null)
            {
                error += "<br/>Password is required";
            }
            if (error != null)
            {
                TempData["Error"] = error;
                return RedirectToAction("AdminIndex");
            }
            else
            {
                Admindal admindal = new Admindal();
                DataTable dt = admindal.Admin_SelectBy_Email_Pass(connstr, adminModel.AdminEmail, adminModel.Adminpassword);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("Adminid", dr["Adminid"].ToString());
                        HttpContext.Session.SetString("AdminEmail", dr["AdminEmail"].ToString());
                        HttpContext.Session.SetString("Adminpassword", dr["Adminpassword"].ToString());
                        HttpContext.Session.SetString("Adminname", dr["Adminname"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is invalid!";
                    return RedirectToAction("AdminIndex");
                }
                if (HttpContext.Session.GetString("AdminEmail") != null && HttpContext.Session.GetString("Adminpassword") != null)
                {

                    return RedirectToAction("Dashboard", "Admin", new { Area = "Admin" });
                }
            }
            return RedirectToAction("AdminIndex");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("AdminIndex");
        }


        public IActionResult Add(int? Adminid)
        {

            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Admindal dalLOC = new Admindal();

            if (Adminid != null)
            {
                DataTable dt = dalLOC.Admin_SelectByPk(connectionstr, Adminid);
                if (dt.Rows.Count > 0)
                {
                    AdminModel Foradmin = new AdminModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Foradmin.Adminid = Convert.ToInt32(dr["Adminid"]);
                        Foradmin.Adminname = dr["Adminname"].ToString();
                        Foradmin.AdminEmail = dr["AdminEmail"].ToString();
                        Foradmin.Adminpassword = dr["Adminpassword"].ToString();
                        Foradmin.AdminMobil = dr["AdminMobil"].ToString();
                        Foradmin.AdminCity = dr["AdminCity"].ToString();
                        Foradmin.AdminState = dr["AdminState"].ToString();
                        Foradmin.AdminCountry = dr["AdminCountry"].ToString();
                        Foradmin.AdminCreationdate = Convert.ToDateTime(dr["AdminCreationdate"]);
                        Foradmin.AdminModificationdate = Convert.ToDateTime(dr["AdminModificationdate"]);

                    }
                    return View("AdminAddEdit", Foradmin);
                }
            }
            return View("AdminAddEdit");
        }


        public IActionResult Save(AdminModel Foradmin)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Admindal Fordata = new Admindal();
            if (Foradmin.Adminid == null)
            {

                if (Convert.ToBoolean(Fordata.Admin_Insert(connectionstr, Foradmin)))
                {
                    TempData["AlertMsg"] = "Record Inserted Successfully";
                }
            }
            else
            {
                if (Convert.ToBoolean(Fordata.Admin_Update(connectionstr, Foradmin)))
                    TempData["AlertMsg"] = "Record Update Successfully";
            }
            return RedirectToAction("AllAdmin");
        }

        public IActionResult Delete(int Adminid)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Admindal Fordata = new Admindal();
            if (Convert.ToBoolean(Fordata.Admin_delete(connectionstr, Adminid)))
                TempData["AlertMsg"] = "Record Delete Successfully";
            else
            {
                TempData["AlertMsg"] = "Not deleted";
            }
            return RedirectToAction("AllAdmin");

        }


    }
}
