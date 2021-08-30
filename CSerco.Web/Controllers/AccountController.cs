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
        readonly ManageRepository _manejoManageServices = new ManageRepository();
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(SignInVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }else if (_manejoManageServices.IniciarSesion(model))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "BAD";
            return View(model);
        }

        public ActionResult NewUser()
        {
            ViewBag.Role = _manejoUserServices.getRoles();
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(UserVM model)
        {
            ViewBag.Role = _manejoUserServices.getRoles();
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