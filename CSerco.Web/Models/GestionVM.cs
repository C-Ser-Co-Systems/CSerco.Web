using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CSerco.Web.Models
{
    public class GestionVM : BaseModel
    {
        public int idGestion { get; set; }
        public int idCliente { get; set; }
        [Required(ErrorMessage = "¡El Numero de Credito es requerido!")]
        public string CodPrestamo { get; set; }
        public DateTime FechaGestion { get; set; }
        [Required(ErrorMessage = "¡El detalle de la gestion requerido!")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "¡El Tipo de la gestion es requerida!")]
        public int IdTipo { get; set; }
        public HttpPostedFileBase FileDoc { get; set; }
        public byte[] FileDocHistory { get; set; }
        public int Days { get; set; }

        public List<GestionVM> GestionesLst { get; set; }
    }
}