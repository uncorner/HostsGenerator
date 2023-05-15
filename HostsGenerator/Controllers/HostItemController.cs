using HostsGenerator.Application.Entities;
using HostsGenerator.Infrastructure;
using HostsGenerator.Presenation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HostsGenerator.Controllers
{
    public class HostItemController : Controller
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

        public HostItemController(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
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

            if (Repository.HostItems.Select(i => i.Domain).Contains(domain))
            {
                return Json(false);
            }
            return Json(true);
        }

        
    }
}
