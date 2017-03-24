using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftawareHouse.Web.ViewModels;
using SoftwareHouse.Contracts.DataContracts;
using SoftwareHouse.Contracts.Services;

namespace SoftawareHouse.Web.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IProjectsService _projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Projects";
            return View();
        }

        [HttpGet]
        public IActionResult Add() => View(new ProjectCreateViewModel());

        [HttpPost]
        public IActionResult Add(ProjectCreateViewModel projectViewModel)
        {

            var result = _projectsService.Add(new AddProjectDto
            {
                Name = projectViewModel.Name,
                Description = projectViewModel.Description,
            });

            if (result.IsSuccess)
                return RedirectToAction(nameof(Index), "Projects");

            projectViewModel.ErrorMessage = result.ErrorMessage;
            return View(projectViewModel);
        }
    }
}