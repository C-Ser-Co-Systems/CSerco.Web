using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSerco.Web.Models
{
    public class SessionData
    {
        private string Session;

        public void setSession(string name, object data)
        {
            HttpContext.Current.Session[name] = data;
        }

        public String getSession(String Name)
        {
            this.Session = Convert.ToString(HttpContext.Current.Session[Name]);

            return Session;
        }

        public void LogOut()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.RemoveAll();
        }
    }
}