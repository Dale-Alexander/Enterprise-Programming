using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //A controller controls the requests and the responses

    //Exercise:
    //Create a TestController.cs
    //Write a method called Test which accepts a parameter string id
    //Method returns back "This is {id} you have input";
    //Optional: create a view which displays the above as html

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //_logger.LogInformation("user accessed index method");

            // a View => ViewResult
            // a File => FileResult
            // json data => JsonResult
            // string => ContentResult
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
