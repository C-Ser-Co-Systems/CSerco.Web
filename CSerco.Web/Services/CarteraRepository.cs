using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSerco.SQL.DataContext;
using CSerco.Web.Models;

namespace CSerco.Web.Services
{
    public class CarteraRepository
    {
        readonly CSercoDBEntities1 db = new CSercoDBEntities1();
        readonly SessionData session = new SessionData();

        public CarteraVM getLst(int page)
        {
            int IdUser = Convert.ToInt32(session.getSession("User"));
            CarteraVM model = new CarteraVM
            {
                CartLst = new List<CarteraVM>()
            };
            var Lst = db.fnPager(page, 4, IdUser);
            foreach(var item in Lst)
            {
                model.CartLst.Add(new CarteraVM
                {
                    IdCartera = (int)item.Id,
                    NCredito = item.NCredito,
                    Nombre = item.Nombre,
                    SaldoK = (decimal)item.Saldo,
                    DiasMora = (int)item.DiasMora,
                    MontVen = (decimal)item.MontoVencido,
                    InteresVen = (decimal)item.MontoVencido,
                    Direccion = item.Direccion,
                    Reestructuracion = item.Res == 1 ? "YA POSEE" : "NO POSEE",
                    OID = item.OID == 1 ? "YA POSEE" : "NO POSEE",
                    Telefono = item.Tel,
                    Correo = item.email
                });
            }
            model.TotalReg = db.Cartera.Where(x => x.Status == 1 && x.IdUser == IdUser).Count();
            model.RegPerPage = 4;
            model.Page = page + 1;

            return model;
        }
    }
}