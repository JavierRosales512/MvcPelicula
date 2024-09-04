using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MvcPelicula.Models
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaCarga { get; set; }

        public string? Genero { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal Price { get; set; }
    }
}
