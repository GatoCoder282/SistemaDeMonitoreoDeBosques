using Microsoft.AspNetCore.Mvc;

namespace SistemaDeMonitoreoDeBosques.Controllers
{
    public class SensorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
