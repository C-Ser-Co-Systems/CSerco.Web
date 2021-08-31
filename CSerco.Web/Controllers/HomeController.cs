using System;
using System.Collections.Generic;
using System.IO;
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


        //------------------------------------------------------END POINTS------------------------------------------------------

        public string RenderPartialToString(string ViewName, object model)
        {
            ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, ViewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);

                return writer.ToString();
            }
        }

        [HttpPost]
        public JsonResult GetDeatilsModal(int id)
        {
            CarteraVM model = _manejoCarteraServices.getCarteraById(id);
            string partial = RenderPartialToString("~/Views/Home/_PartialDetalleCartera.cshtml", model);

            return Json(new { partial }, JsonRequestBehavior.AllowGet);
        }
    }
}