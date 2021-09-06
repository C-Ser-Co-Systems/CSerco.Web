using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using CSerco.Web.Models;
using CSerco.SQL.DataContext;
using System.Diagnostics;
using System.Web.Mvc;
using System.Data.Entity;

namespace CSerco.Web.Services
{
    public class ClienteRepository
    {
        readonly CSercoDBEntities1 db = new CSercoDBEntities1();
        readonly SessionData session = new SessionData();

        public bool NewClient(ClienteVM model)
        {
            try
            {
                Cliente DbModel = new Cliente
                {
                    Nombre = model.Nombre,
                    DUI = model.DUI,
                    NIT = model.NIT,
                    IdDpto = model.idDpto,
                    IdMncpo = model.idMncpo,
                    Direccion = model.Direcc,
                    LugarT = model.LTrabajo,
                    Tel = model.Tel,
                    Tel2 = model.Tel2,
                    IdUserRegistra = Convert.ToInt32(session.getSession("User")),
                    IdUser = Convert.ToInt32(session.getSession("User")),
                    FLastUpdate = DateTime.Today,
                    Status = 1
                };
                db.Cliente.Add(DbModel);
                db.SaveChanges();
                //Eliminamos el registro de la cartera, a partir de este punto
                //Toda gestion adicional debera ser ingresada a partir del cliente
                var Cartera = db.Cartera.Where(x => x.IdCartera == model.IdCartera).Single();
                Cartera.Status = 0;
                db.Entry(Cartera).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                Debug.WriteLine("Exception Message: " + e.Message);
                return false;
            }
        }

        public List<SelectListItem> getDtpos()
        {
            var lst = db.Departamentos
                .OrderBy(x => x.DptoName).ToList();
            List<SelectListItem> List = new List<SelectListItem>();
            foreach (var item in lst)
            {
                List.Add(new SelectListItem
                {
                    Text = item.DptoName,
                    Value = item.IdDpto.ToString()
                });
            }

            return List;
        }

        public List<SelectListItem> getMncpoByDpto(int id)
        {
            var lst = db.Municipios
                .OrderBy(x => x.MncpoName)
                .Where(x => x.IdDpto == id).ToList();
            List<SelectListItem> List = new List<SelectListItem>();
            foreach (var item in lst)
            {
                List.Add(new SelectListItem
                {
                    Text = item.MncpoName,
                    Value = item.IdMncpo.ToString()
                });
            }

            return List;
        }

        public ClienteVM GetClientByCodP(string CodP)
        {
            //Obtiene al cliente segun el Numero de credito
            var DbGest = db.Gestion.Where(x => x.CodPrestamo == CodP).Single();

            Cliente DbModel = db.Cliente.Where(x => x.IdCliente == DbGest.IdCliente).Single();
            ClienteVM model = new ClienteVM
            {
                IdCartera = db.Cartera.Where(x => x.NCredito == CodP && x.Status == 1).Single().IdCartera,
                IdCliente = DbModel.IdCliente,
                Nombre = DbModel.Nombre,
                DUI = DbModel.DUI,
                NIT = DbModel.NIT,
                idDpto = (int)DbModel.IdDpto,
                idMncpo = (int)DbModel.IdMncpo,
                Direcc = DbModel.Direccion,
                Tel = DbModel.Tel,
                Tel2 = DbModel.Tel2
            };

            return model;
        }

        public bool ValidationClientExist(string codP)
        {
            //Devuelve true si hay una gestion existente para cliente (es decir que el cliente existe), false si no existe!
            int Count = db.Gestion.Where(x => x.CodPrestamo == codP).Count();
            if (Count > 0)
                return true;
            return false;
        }
    }
}