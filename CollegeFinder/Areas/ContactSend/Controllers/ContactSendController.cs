using Microsoft.AspNetCore.Mvc;
using System.Data;
using CollegeFinder.Areas.User.Models;
using CollegeFinder.DAL;
using CollegeFinder.BAL;
using System.Data.SqlClient;

namespace CollegeFinder.Areas.ContactSend.Controllers
{
     
    [CheckAccess]
    [Area("ContactSend")]
    [Route("ContactSend/[controller]/[action]")]
    public class ContactSendController : Controller
    {
        private IConfiguration Configuration;

        #region Con
        public ContactSendController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        #endregion

        public IActionResult Index()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Adminpanel dalLOC = new Adminpanel();
            DataTable dt = dalLOC.Contact_Send_SelectAll(connectionstr);
            return View("Index", dt);
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Delete(int? ContactId)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Adminpanel dalLOC = new Adminpanel();

            if (Convert.ToBoolean(dalLOC.ContactSend_Delete(connectionstr, ContactId)))
                TempData["Contactsendalert"] = "Record Delete Successfully";
            else
            {
                TempData["Contactsendalert"] = "Not deleted";
            }
            return RedirectToAction("Index");
        }


    }
}
