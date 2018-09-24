using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public static class SessionHelper
    {
        private const string Username = "Username";
        private const string Role = "Role";
        private const string Administrator = "Administrator";
        private const string DefaultRole = "Member";

        public static void LogUserIn(string username, string role)
        {
            HttpContext.Current.Session[Username] = username;
            HttpContext.Current.Session[Role] = role;
        }

        public static void LogUserIn(string username)
        {
            LogUserIn(username, DefaultRole);
        }

        public static bool IsUserLoggedIn()
        {
            if (HttpContext.Current.Session[Username] == null)
                return false;
            return true;
        }
        public static void LogOut()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}