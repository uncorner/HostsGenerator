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
                var hostItem = new HostItem(form.Url) { Name = form.Name };
                Repository.HostItems.Add(hostItem);

                return RedirectToAction("Index", "Home");
            }

            return View(form);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckUrlExists(string url)
        {
            if (Repository.HostItems.Select(i => i.Url).Contains(url))
            {
                return Json(false);
            }
            return Json(true);
        }

        
    }
}
