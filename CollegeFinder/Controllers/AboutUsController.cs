using Microsoft.AspNetCore.Mvc;
using CollegeFinder.DAL;
using System.Configuration;
using CollegeFinder.Models;

namespace CollegeFinder.Controllers
{
    public class AboutUsController : Controller
    {
        private IConfiguration Configuration;


        public AboutUsController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult AboutUs()
        {
            return View();
        }

    }
}
