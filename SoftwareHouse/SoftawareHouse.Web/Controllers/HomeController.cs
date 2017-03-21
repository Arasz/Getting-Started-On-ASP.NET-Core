using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SoftawareHouse.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction(nameof(ProjectsController.Index), "Projects");

            ViewData["Title"] = "Home page";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Software house project manager.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "https://github.com/Arasz";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
