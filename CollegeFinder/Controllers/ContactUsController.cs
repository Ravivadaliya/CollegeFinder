using Microsoft.AspNetCore.Mvc;
using CollegeFinder.DAL;
using System.Configuration;
using CollegeFinder.Models;

namespace CollegeFinder.Controllers
{
    public class ContactUsController : Controller
    {
        private IConfiguration Configuration;


        public ContactUsController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Save(Contact_SendModel contact_Send)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Client Fordata = new Client();
            if (contact_Send.Contact_Id == null)
            {

                if (Convert.ToBoolean(Fordata.Contact_Send_Insert(connectionstr, contact_Send)))
                {
                    TempData["AlertMsg"] = "Send Your Message Our Team";
                }
            }
            else
            {
                TempData["AlertMsg"] = "Not Send Properly";
            }


            return RedirectToAction("ContactUs");


        }
    }
}
