//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSerco.SQL.DataContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cartera
    {
        public int IdCartera { get; set; }
        public string NCredito { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public Nullable<int> DiasMora { get; set; }
        public Nullable<decimal> MontoVencido { get; set; }
        public Nullable<decimal> InteresVencido { get; set; }
        public string Direccion { get; set; }
        public Nullable<System.DateTime> FLastPay { get; set; }
        public Nullable<decimal> Mes10 { get; set; }
        public Nullable<decimal> Mes11 { get; set; }
        public Nullable<decimal> Mes12 { get; set; }
        public Nullable<int> Res { get; set; }
        public Nullable<int> OID { get; set; }
        public string Tel { get; set; }
        public string email { get; set; }
        public Nullable<int> IdUser { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
