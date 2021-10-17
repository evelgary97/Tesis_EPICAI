using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tesis_EPICAI.ViewModels.Usuarios
{
    public class Create
    {
        [Required(ErrorMessage = "Nombre obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor rellene el campo")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repetir contraseña")]
        [Required(ErrorMessage = "Por favor rellene el campo")]
        [Compare("Password", ErrorMessage = "Las contraseñas deben coincidir")]
        public string Password2 { get; set; }
    }
}
