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
        readonly ClienteRepository _manejoClienteServices = new ClienteRepository();
        public ActionResult Index(int? page)
        {
            page = page == null ? 0 : page-1;

            CarteraVM model = _manejoCarteraServices.getLst((int)page);
            return View(model);
        }

        public ActionResult RegisterClient(string CodP)
        {
            ViewBag.Departamentos = _manejoClienteServices.getDtpos();
            if (_manejoClienteServices.ValidationClientExist(CodP))
            {
                ClienteVM model = _manejoClienteServices.GetClientByCodP(CodP);
                RedirectToAction("EditarCliente", "Home", model);
            }
            else
            {
                ClienteVM model = _manejoClienteServices.fromCarteraToClient(CodP);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult RegisterClient(ClienteVM model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        public ActionResult EditarCliente(int id)
        {
            ViewBag.Departamentos = _manejoClienteServices.getDtpos();
            return View();
        }

        //------------------------------------------------------END POINTS------------------------------------------------------
        [HttpGet]
        public JsonResult Departamentos()
        {
            var departamentos = _manejoClienteServices.getDtpos();
            return Json(departamentos, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Municipios(int id)
        {
            var municipios = _manejoClienteServices.getMncpoByDpto(id);
            return Json(municipios, JsonRequestBehavior.AllowGet);
        }

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