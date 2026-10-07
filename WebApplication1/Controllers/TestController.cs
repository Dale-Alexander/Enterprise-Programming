using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Test(string id)
        {
            TempData["message"] = $"This is the {id} input you wrote";

            return View();
        }
    }
}
