using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Test(string id)
        {
            //Ways to pass data from server => client side
            //TempData, Context, ViewData, ViewBag
            //...are all built-in objects that come available in web applications .NET
            //and then there are Models/ViewModels
            TempData["message"] = $"This is the {id} input you wrote";
            //TempData will be used to pass messages to the user

            return View();
        }
    }
}
