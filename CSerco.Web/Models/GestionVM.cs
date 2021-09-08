using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CSerco.Web.Models
{
    public class GestionVM
    {
        public int idGestion { get; set; }
        public int idCliente { get; set; }
        [Required(ErrorMessage = "¡El Numero de Credito es requerido!")]
        public string CodPrestamo { get; set; }
        [Required(ErrorMessage = "¡El nombre del cliente es requerido!")]
        public string NombreDeudor { get; set; }
        [Required(ErrorMessage = "¡Por favor seleccione un Departamento!")]
        public int IdDpto { get; set; }
        [Required(ErrorMessage = "¡Por favor seleccione un Municipio!")]
        public int IdMncpo { get; set; }
        [Required(ErrorMessage = "¡La Urbanizacion es requerida!")]
        public string Urbanizacion { get; set; }
        [Required(ErrorMessage = "¡La direccion del cliente es requerida!")]
        public string Direccion { get; set; }
        public DateTime FechaGestion { get; set; }
        [Required(ErrorMessage = "¡El detalle de la gestion requerido!")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "¡El Tipo de la gestion es requerida!")]
        public int IdTipo { get; set; }
        public HttpPostedFileBase FileDoc { get; set; }

        public List<GestionVM> GestionesLst { get; set; }
    }
}