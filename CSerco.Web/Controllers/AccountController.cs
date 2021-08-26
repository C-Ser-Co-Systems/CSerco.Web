using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSerco.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult NewUser()
        {
            return View();
        }
    }
}