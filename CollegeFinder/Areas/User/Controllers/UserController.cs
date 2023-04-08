using Microsoft.AspNetCore.Mvc;
using System.Data;
using CollegeFinder.Areas.User.Models;
using CollegeFinder.DAL;
using CollegeFinder.BAL;
using System.Data.SqlClient;

namespace CollegeFinder.Areas.User.Controllers
{

    [CheckAccess]
    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class UserController : Controller
    {
        private IConfiguration Configuration;

        #region Con
        public UserController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        #endregion

        public IActionResult Index()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            AllData dalLOC = new AllData();
            DataTable dt = dalLOC.User_SelectAll(connectionstr);
            return View("Index", dt);
        }
        public IActionResult Dashboard()
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

        public IActionResult Delete(int? userid)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            AllData dalLOC = new AllData();

            if (Convert.ToBoolean(dalLOC.userdelete(connectionstr, userid)))
                TempData["AlertMsg"] = "Record Delete Successfully";
            else
            {
                TempData["AlertMsg"] = "Not deleted";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Add(int? userid)
        {

            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");

            AllData dalLOC = new AllData();

            if (userid != null)
            {
                DataTable dt = dalLOC.user_selectByPk(connectionstr, userid);
                if (dt.Rows.Count > 0)
                {
                    UserModel ForCollege = new UserModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ForCollege.userid = Convert.ToInt32(dr["userid"]);
                        ForCollege.usename = dr["usename"].ToString();
                        ForCollege.usermobile= dr["usermobile"].ToString();
                        ForCollege.usermailid = dr["usermailid"].ToString();
                        ForCollege.usercity = dr["usercity"].ToString();
                        ForCollege.userstate = dr["userstate"].ToString();
                        ForCollege.usercountry = dr["usercountry"].ToString();
                        ForCollege.userpassword= dr["userpassword"].ToString();
                        ForCollege.creationdate =Convert.ToDateTime(dr["Creationdate"]);
                        ForCollege.modificationdate = Convert.ToDateTime(dr["Modificationdate"]);

                    }
                    return View("UserAddEdit", ForCollege);
                }
            }
            return View("UserAddEdit");
        }


        public IActionResult Save(UserModel Foruser)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            AllData Fordata = new AllData();
            if (Foruser.userid == null)
            {
                if (Convert.ToBoolean(Fordata.User_insert(connectionstr, Foruser)))
                {
                    TempData["AlertMsg"] = "Record Inserted Successfully";
                }
            }
            else
            {
                if (Convert.ToBoolean(Fordata.User_Update(connectionstr, Foruser)))
                    TempData["AlertMsg"] = "Record Update Successfully";
            }


            return RedirectToAction("Index");
        }



        public IActionResult UserAddEdit()
        {
            return View();
        }


    }
}
