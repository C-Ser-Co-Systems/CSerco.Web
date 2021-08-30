using CSerco.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSerco.Web.Filters
{
    public class AEmployee : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = HttpContext.Current.Session["User"];
            var userRol = HttpContext.Current.Session["Rol"];

            if (user == null || userRol == null)
            {
                filterContext.Result = new RedirectResult("~/Account/LogIn");
            }

            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var user = HttpContext.Current.Session["User"];
            var userRol = HttpContext.Current.Session["Rol"];

            if (user == null || userRol == null)
            {
                filterContext.Result = new RedirectResult("~/Account/LogIn");
            }

            base.OnActionExecuted(filterContext);
        }
    }
}