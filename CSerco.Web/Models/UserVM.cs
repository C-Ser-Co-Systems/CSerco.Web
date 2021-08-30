using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CSerco.Web.Models
{
    public class UserVM
    {
        public int IdUser { get; set; }
        [Required(ErrorMessage ="Debe definir un rol para el usuario!")]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es requerido!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Debe confirmar la contraseña!")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fLastUpdate { get; set; }

        public List<UserVM> UserLst { get; set; }

    }
}