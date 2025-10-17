using Microsoft.AspNetCore.Mvc;

namespace SistemaDeMonitoreoDeBosques.Controllers
{
    public class ForestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
