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
    
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.ClientFlag = new HashSet<ClientFlag>();
            this.Gestion = new HashSet<Gestion>();
        }
    
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        public Nullable<int> IdDpto { get; set; }
        public Nullable<int> IdMncpo { get; set; }
        public string Direccion { get; set; }
        public string LugarT { get; set; }
        public string Tel { get; set; }
        public string Tel2 { get; set; }
        public Nullable<int> IdUser { get; set; }
        public Nullable<int> IdUserRegistra { get; set; }
        public Nullable<System.DateTime> FLastUpdate { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual Departamentos Departamentos { get; set; }
        public virtual Municipios Municipios { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientFlag> ClientFlag { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gestion> Gestion { get; set; }
    }
}
