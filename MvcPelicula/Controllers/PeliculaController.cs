using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Xml.Linq;

namespace MvcPelicula.Controllers
{
    public class PeliculaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
