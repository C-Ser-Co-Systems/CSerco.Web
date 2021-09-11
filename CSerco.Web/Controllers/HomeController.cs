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
        readonly GestionRepository _manejoGestionServices = new GestionRepository();
        public ActionResult Index(int? page)
        {
            if (_manejoClienteServices.verifyClientsFlags())
            {
                ViewBag.Message = "ALERT";
                ViewBag.Gestion = _manejoClienteServices.getUnmanageClientId();
            }
            page = page == null ? 0 : page - 1;
            CarteraVM model = _manejoCarteraServices.getLst((int)page);

            return View(model);
        }

        public ActionResult ClientList(int? page)
        {
            return View();
        }

        public ActionResult GestionList(int? page)
        {
            if (_manejoClienteServices.verifyClientsFlags())
            {
                ViewBag.Message = "ALERT";
                ViewBag.Gestion = _manejoClienteServices.getUnmanageClientId();
            }
            page = page == null ? 0 : page - 1;
            GestionVM model = _manejoGestionServices.getGestionLst((int)page);

            return View();
        }

        public ActionResult RegisterClient(string CodP)
        {
            if (_manejoClienteServices.verifyClientsFlags())
            {
                ViewBag.Message = "ALERT";
                ViewBag.Gestion = _manejoClienteServices.getUnmanageClientId();
            }
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
                if (_manejoClienteServices.NewClient(model))
                {
                    model.IdCliente = _manejoClienteServices.getUnmanageClientId();
                    RedirectToAction("RegistrarGestion", "Home", model.IdCliente);
                }
            }
            return View();
        }

        public ActionResult EditarCliente(int id)
        {
            ViewBag.Departamentos = _manejoClienteServices.getDtpos();
            if (_manejoClienteServices.verifyClientsFlags())
            {
                ViewBag.Message = "ALERT";
                ViewBag.Gestion = _manejoClienteServices.getLastClientID();
            }
            return View();
        }

        public ActionResult RegistrarGestion(int idClient)
        {
            GestionVM model = _manejoGestionServices.getClientDataFromGestion(idClient);
            ViewBag.TipoGestion = _manejoGestionServices.getTipoList();
            return View(model);
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