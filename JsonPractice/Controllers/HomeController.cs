using JsonPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using JsonPractice.Models.Class;
using static JsonPractice.Models.Class.Products;

namespace JsonPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var json = System.IO.File.ReadAllText("wwwroot\\json\\products.json");
            var data = JsonConvert.DeserializeObject<Rootobject>(json);
            var product = data.products;
            return View(product);
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