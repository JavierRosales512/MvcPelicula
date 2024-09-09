using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcPelicula.Datos;
using MvcPelicula.Models;
using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Xml.Linq;

namespace MvcPelicula.Controllers
{
    public class PeliculaController : Controller
    {

        private readonly DbContexto _ContextoDb;

        public PeliculaController(DbContexto ContextoDb)
        {
            _ContextoDb = ContextoDb;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _ContextoDb.Peliculas.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
