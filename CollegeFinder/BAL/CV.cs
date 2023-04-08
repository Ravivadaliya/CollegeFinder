using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CollegeFinder.Areas.Admin.Models;
using CollegeFinder.DAL;
using System.Configuration;

namespace CollegeFinder.BAL
{
    public static class CV
    {
        private static IHttpContextAccessor _httpContextAccessor;

        static CV()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        public static string? Adminid()
        {
            string? Adminid = null;
            
            if (_httpContextAccessor.HttpContext.Session.GetString("Adminname") != null)
            {
                Adminid = _httpContextAccessor.HttpContext.Session.GetString("Adminname").ToString();
            }
            return Adminid;
        }
        public static string? Adminemail()
        {
            string? Adminemail = null;

            if (_httpContextAccessor.HttpContext.Session.GetString("AdminEmail") != null)
            {
                Adminemail = _httpContextAccessor.HttpContext.Session.GetString("AdminEmail").ToString();
            }
            return Adminemail;
        }
        public static string? Adminpassword()
        {
            string? Adminpassword = null;

            if (_httpContextAccessor.HttpContext.Session.GetString("Adminpassword") != null)
            {
                Adminpassword = _httpContextAccessor.HttpContext.Session.GetString("Adminpassword").ToString();
            }
            return Adminpassword;
        }

        public static int? UserID()
        {
            int? UserID = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("UserID") != null)
            {
                UserID = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserID"));
            }
            return UserID;
        }

    }
}
