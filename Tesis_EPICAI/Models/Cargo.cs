using System.ComponentModel.DataAnnotations;

namespace Tesis_EPICAI.Models
{
    public class Cargo
    {
        [Key]
        public int Id { get; set; }

        [Required] public string Nombre { get; set; }

        [Required]
        [Display(Name = "Media salarial")]
        public int Salario { get; set; }

        [Display(Name = "Descripción")] public string Descripcion { get; set; }

        public override string ToString()
        {
            return Nombre;
        }


    }
}