using HostsGenerator.Application.Entities;
using HostsGenerator.Application.Repository;
using HostsGenerator.Infrastructure;
using HostsGenerator.Presenation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HostsGenerator.Controllers
{
    public class HostItemController : Controller
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;
        private readonly IRepositoryFactory repositoryFactory;

        public HostItemController(IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IRepositoryFactory repositoryFactory)
        {
            this.dbContextFactory = dbContextFactory;
            this.repositoryFactory = repositoryFactory;
        }
        
        public IActionResult Create()
        {
            return View(new HostItemForm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HostItemForm form)
        {
            if (ModelState.IsValid)
            {
                var hostItem = new HostItem(form.Domain.Trim()) {
                    Description = form.Description?.Trim(), IsEnabled = form.IsEnabled
                };

                //>>>>>>>>>
                //Repository.HostItems.Add(hostItem);
                using(var dbContext = dbContextFactory.CreateDbContext())
                {
                    dbContext.HostItems.Add(hostItem);
                    await dbContext.SaveChangesAsync();
                }

                return RedirectToAction("Index", "Home");
            }

            return View(form);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckDomainExists(string domain)
        {
            domain = domain.Trim();

            using var dbContext = dbContextFactory.CreateDbContext();
            var hostItemRepository = repositoryFactory.GetHostItemRepository(dbContext);

            if (hostItemRepository.HasHostItemWithDomain(domain))
            {
                return Json(false);
            }
            return Json(true);
        }

        
    }
}
