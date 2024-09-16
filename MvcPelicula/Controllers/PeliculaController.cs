using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcPelicula.Datos;
using MvcPelicula.Models;
using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Xml.Linq;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace MvcPelicula.Controllers
{
    public class PeliculaController : Controller
    {
        //---- Contexto
        private readonly DbContexto _ContextoDb;

        //---- Objeto 


        public PeliculaController(DbContexto ContextoDb)
        {
            _ContextoDb = ContextoDb;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _ContextoDb.Peliculas.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Pelicula pelicula)
        {

            pelicula.FechaCarga = DateTime.Now.Date;

            if (ModelState.IsValid)
            {
                _ContextoDb.Peliculas.Add(pelicula);
                await _ContextoDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pelicula pelicula = _ContextoDb.Peliculas.Find(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pelicula pelicula = _ContextoDb.Peliculas.Find(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                _ContextoDb.Update(pelicula);
                await _ContextoDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pelicula pelicula = _ContextoDb.Peliculas.Find(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> EliminarPelicula(Pelicula pelicula)
        {
            if (_ContextoDb != null && _ContextoDb.Peliculas != null)
            {
                _ContextoDb.Peliculas.Remove(pelicula);
                await _ContextoDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
