using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;
using Tesis_EPICAI.Models;

namespace Tesis_EPICAI.Models
{
    public class Trabajador
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Rellene el campo nombre")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "Rellene el campo carnet de identidad")]
        [Display(Name = "Carnet de identidad")]
        [RegularExpression("[0-9]{11}")]
        public string Ci { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numero de teléfono")]
        public string NumeroTelefono { get; set; }

        [Required(ErrorMessage = "Rellene el campo dirección")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required] 
        public Cargo Cargo { get; set; }
    }
}