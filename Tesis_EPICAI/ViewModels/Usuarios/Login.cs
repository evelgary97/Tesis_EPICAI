using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tesis_EPICAI.ViewModels.Usuarios
{
    public class Login
    {
        [Required(ErrorMessage = "Por favor escriba su nombre de usuario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Por favor escriba su contraseña")]
        public string Password { get; set; }
    }
}
