using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSerco.Web.Filters
{
    public class Access : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var user = HttpContext.Current.Session["User"];
            var userRol = HttpContext.Current.Session["Rol"].ToString();

            if(user == null)
            {
                filterContext.Result = new RedirectResult("~/Account/LogIn");
            }else if(user != null && userRol == "3")
            {
                filterContext.Result = new RedirectResult("~/Account/LogIn");
            }
            base.OnActionExecuted(filterContext);
        }
    }
}