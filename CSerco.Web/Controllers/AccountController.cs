using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSerco.Web.Models;
using CSerco.Web.Services;

namespace CSerco.Web.Controllers
{
    public class AccountController : Controller
    {
        readonly UsersRepository _manejoUserServices = new UsersRepository();
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(UserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                if (_manejoUserServices.AddNewUser(model))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "BAD";
                    return View(model);
                }
            }
        }
    }
}