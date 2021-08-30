using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSerco.Web.Models
{
    public class CarteraVM : BaseModel
    {
        public int IdCartera { get; set; }
        public string NCredito { get; set; }
        public string Nombre { get; set; }
        public decimal SaldoK { get; set; }
        public int DiasMora { get; set; }
        public decimal MontVen { get; set; }
        public decimal InteresVen { get; set; }
        public string Direccion { get; set; }
        public string Reestructuracion { get; set; }
        public string OID { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public List<CarteraVM> CartLst { get; set; }
    }
}