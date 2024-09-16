using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MvcPelicula.Models
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; } = string.Empty;

        [Display(Name = "Fecha de Carga")]
        [DataType(DataType.Date)]
        public DateTime FechaCarga { get; set; }

        [Display(Name = "Género")]
        public string? Genero { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal Price { get; set; }
    }
}
