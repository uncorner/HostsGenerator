using HostsGenerator.Application.Entities;
using HostsGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HostsGenerator.Controllers
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
            HostItem[] hosts = new[] { 
                new HostItem("host url 111"),
                new HostItem("host url 222"),
                new HostItem("host url 333"),
                new HostItem("host url 444"),
                new HostItem("host url 555")
            };

            return View(hosts);
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