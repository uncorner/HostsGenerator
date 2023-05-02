using HostsGenerator.Application.Entities;
using HostsGenerator.Infrastructure;
using HostsGenerator.Presenation.Models;
using Microsoft.AspNetCore.Mvc;

namespace HostsGenerator.Controllers
{
    public class HostItemController : Controller
    {
        
        public ActionResult Create()
        {
            return View(new HostItemForm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HostItemForm form)
        {
            if (ModelState.IsValid)
            {
                var hostItem = new HostItem(form.Url) { Name = form.Name };
                Repository.HostItems.Add(hostItem);

                return RedirectToAction("Index", "Home");
            }

            //return Content("Model is not valid");
            return View(form);
        }

        
    }
}
