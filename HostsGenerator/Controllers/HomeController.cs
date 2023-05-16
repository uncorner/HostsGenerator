using HostsGenerator.Application.Repository;
using HostsGenerator.Infrastructure;
using HostsGenerator.Presenation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HostsGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;
        private readonly IRepositoryFactory repositoryFactory;

        public HomeController(ILogger<HomeController> logger,
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IRepositoryFactory repositoryFactory)
        {
            _logger = logger;
            this.dbContextFactory = dbContextFactory;
            this.repositoryFactory = repositoryFactory;
        }

        public IActionResult Index()
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var hostItemRepository = repositoryFactory.GetHostItemRepository(dbContext);
            var hostItems = hostItemRepository.GetAll();
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