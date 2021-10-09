using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tesis_EPICAI.Models
{
    //instrumentos o herramientas necesarias para el trabajo
    public class Instrumentos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Rellene el campo nombre")]
        public string Nombre { get; set; }
        
        [Display(Name = "Costo por unidad")]
        [DefaultValue(0)]
        public int Costo { get; set; }
    }
}
