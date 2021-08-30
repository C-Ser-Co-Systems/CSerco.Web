using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSerco.Web.Filters;
using CSerco.Web.Models;
using CSerco.Web.Services;

namespace CSerco.Web.Controllers
{
    [AEmployee]
    public class HomeController : Controller
    {
        readonly CarteraRepository _manejoCarteraServices = new CarteraRepository();
        public ActionResult Index(int? page)
        {
            page = page == null ? 0 : page-1;

            CarteraVM model = _manejoCarteraServices.getLst((int)page);
            return View(model);
        }
    }
}