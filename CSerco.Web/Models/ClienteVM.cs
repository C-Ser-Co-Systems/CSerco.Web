using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CSerco.Web.Models
{
    public class ClienteVM
    {
        public int IdCartera { get; set; }
        public int IdCliente { get; set; }
        [Required(ErrorMessage ="¡El nombre completo es requerido!")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="¡El DUI es requerido!")]
        [RegularExpression(@"^\d{8}-\d{1}$", ErrorMessage = "¡El DUI ingresado no es válido!")]
        public string DUI { get; set; }
        public string NIT { get; set; }
        [Required(ErrorMessage = "¡Por favor seleccione un Departamento!")]
        public int idDpto { get; set; }
        [Required(ErrorMessage = "¡Por favor seleccione un Municipio!")]
        public int idMncpo { get; set; }
        [Required(ErrorMessage = "¡Ingrese una dirección para el cliente!")]
        public string Direcc { get; set; }
        public string LTrabajo { get; set; }
        [Required(ErrorMessage = "¡Debe registrar al menos 1 telefono para el cliente!")]
        [RegularExpression(@"(\+503|00503|503)?[ -]*(6|7)([0-9][ -]*){7}", ErrorMessage = "¡El número ingresado no es válido!")]
        public string Tel { get; set; }
        [RegularExpression(@"(\+503|00503|503)?[ -]*(6|7)([0-9][ -]*){7}", ErrorMessage = "¡El número ingresado no es válido!")]
        public string Tel2 { get; set; }
        public int IdUserT { get; set; }
        public int IdUserReg { get; set; }
        public DateTime FLastUpd { get; set; }

        public List<ClienteVM> ClientLst { get; set; }
    }
}