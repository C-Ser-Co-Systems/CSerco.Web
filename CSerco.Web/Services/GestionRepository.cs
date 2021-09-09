using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using CSerco.Web.Models;
using CSerco.SQL.DataContext;
using System.IO;
using System.Web.Mvc;

namespace CSerco.Web.Services
{
    public class GestionRepository
    {
        readonly CSercoDBEntities1 db = new CSercoDBEntities1();
        readonly SessionData session = new SessionData();

        public GestionVM getGestionLst(int page)
        {
            int idUs = Convert.ToInt32(session.getSession("User"));
            GestionVM model = new GestionVM
            {
                GestionesLst = new List<GestionVM>()
            };
            var DbLst = db.fnPagerGestion(page, 6, idUs);
            foreach (var item in DbLst)
            {
                model.GestionesLst.Add(new GestionVM
                {
                    idGestion = (int)item.IdGestion,
                    idCliente = (int)item.IdCliente,
                    CodPrestamo = item.CodPrestamo,
                    FechaGestion = (DateTime)item.FechaGestion,
                    IdTipo = (int)item.IdTipo,
                    FileDocHistory = item.ImgDoc,
                    Days = Convert.ToInt32(((DateTime)item.FechaGestion - DateTime.Today).TotalDays)
                });
            }
            model.TotalReg = db.Gestion
                .Include("Cliente")
                .Where(x => x.Status == 1 && x.Cliente.IdUser == idUs)
                .Count();
            model.RegPerPage = 6;
            model.Page = page + 1;

            return model;
        }

        public List<SelectListItem> getTipoList()
        {
            List<SelectListItem> TipoLst = new List<SelectListItem>();
            var Lst = db.TipoAcuerdo.Where(x => x.Status == 1).ToList();
            foreach(var item in Lst)
            {
                TipoLst.Add(new SelectListItem
                {
                    Text = item.Tipo,
                    Value = item.IdTipo.ToString()
                });
            }

            return TipoLst;
        }

        public GestionVM getClientDataFromGestion(int idC)
        {
            var Data = db.ClientFlag.Where(x => x.IdCliente == idC && x.Status == 1).Single();
            GestionVM model = new GestionVM
            {
                idCliente = idC,
                CodPrestamo = Data.CodP
            };
            return model;
        }
    }
}