using Microsoft.AspNetCore.Mvc;

namespace sistema.Controllers
{
    public class AtividadeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
