using HostsGenerator.Application.Entities;
using HostsGenerator.Application.Repository;
using HostsGenerator.Presenation.Models;
using Microsoft.AspNetCore.Mvc;

namespace HostsGenerator.Controllers
{
    public class HostItemController : Controller
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public HostItemController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
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

                using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
                var hostItemRepository = unitOfWork.CreateHostItemRepository();
                hostItemRepository.Add(hostItem);
                await unitOfWork.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(form);
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> CheckDomainExists(string domain)
        {
            domain = domain.Trim();

            using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var hostItemRepository = unitOfWork.CreateHostItemRepository();

            if (await hostItemRepository.HasHostItemAsync(domain))
            {
                return Json(false);
            }
            return Json(true);
        }

        
    }
}
