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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _projectsService.SoftlyDelete(id);

            return RedirectToAction(nameof(Index), "Projects");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var result = _projectsService.GetById(id);

            var fetchedProject = result.ResultData;

            return View(new ProjectViewModel
            {
                Id = fetchedProject.Id,
                Name = fetchedProject.Name,
                Description = fetchedProject.Description,
                CreationDate = fetchedProject.CreationDate
            });

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