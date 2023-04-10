using CollegeFinder.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using CollegeFinder.Models;
namespace CollegeFinder.Controllers
{
    public class Contact_Send : Controller
    {
        private IConfiguration Configuration;


        public Contact_Send(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

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
