using HostsGenerator.Application.Repository;
using HostsGenerator.Presenation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HostsGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        //private readonly ILogger<HomeController> _logger;

        public HomeController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<IActionResult> Index()
        {
            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var hostItemRepository = unitOfWork.CreateHostItemRepository();
            var hostItems = await hostItemRepository.GetAllAsync();
            return View(hostItems);
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