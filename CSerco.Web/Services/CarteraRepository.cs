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
            var Lst = db.fnPager(page, 6, IdUser);
            foreach(var item in Lst)
            {
                model.CartLst.Add(new CarteraVM
                {
                    IdCartera = (int)item.Id,
                    NCredito = item.NCredito,
                    Nombre = item.Nombre,
                    SaldoK = (decimal)item.Saldo
                });
            }
            model.TotalReg = db.Cartera.Where(x => x.Status == 1 && x.IdUser == IdUser).Count();
            model.RegPerPage = 6;
            model.Page = page + 1;

            return model;
        }

        public CarteraVM getCarteraById(int id)
        {
            Cartera DbModel = db.Cartera.Where(x => x.IdCartera == id).Single();
            CarteraVM model = new CarteraVM
            {
                IdCartera = (int)DbModel.IdCartera,
                NCredito = DbModel.NCredito,
                Nombre = DbModel.Nombre,
                SaldoK = (decimal)DbModel.Saldo,
                DiasMora = (int)DbModel.DiasMora,
                //MontVen se refiere al adeudo total
                MontVen = (decimal)DbModel.MontoVencido,
                InteresVen = (decimal)DbModel.InteresVencido,
                Direccion = DbModel.Direccion,
                FLastPay = (DateTime)DbModel.FLastPay,
                Mes10 = (decimal)DbModel.Mes10,
                Mes11 = (decimal)DbModel.Mes11,
                Mes12 = (decimal)DbModel.Mes12,
                Rees = DbModel.Res == 1 ? "YA POSEE" : "NO POSEE",
                OID = DbModel.OID == 1 ? "YA POSEE" : "NO POSEE",
                Telefono = DbModel.Tel,
                Correo = DbModel.email
            };

            return model;
        }
    }
}