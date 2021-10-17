using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tesis_EPICAI.Models;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;

namespace Tesis_EPICAI.ViewsModels
{
    public class TrabajadorAdd
    {
        public int Id { get; set; }

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

        public int CargoId { get; set; }

        public List<SelectListItem> ListItems { get; set; }
    }
}