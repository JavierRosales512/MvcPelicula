using Microsoft.EntityFrameworkCore;
using MvcPelicula.Models;

namespace MvcPelicula.Datos
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> opciones) 
        :base (opciones)
        { }

        //--------------------
        public DbSet<Pelicula> Peliculas { get; set; }
    }
}
