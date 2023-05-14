using HostsGenerator.Application.Entities;
using HostsGenerator.Infrastructure;
using HostsGenerator.Presenation.Models;
using Microsoft.AspNetCore.Mvc;

namespace HostsGenerator.Controllers
{
    public class HostItemController : Controller
    {
        
        public IActionResult Create()
        {
            return View(new HostItemForm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HostItemForm form)
        {
            if (ModelState.IsValid)
            {
                var hostItem = new HostItem(form.Domain.Trim()) {
                    Name = form.Name?.Trim(), IsEnabled = form.IsEnabled
                };
                Repository.HostItems.Add(hostItem);

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
