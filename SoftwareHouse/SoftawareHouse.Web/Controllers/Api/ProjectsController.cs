using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareHouse.Contracts.Services;

namespace SoftawareHouse.Web.Controllers.Api
{
    [Route("Api/[controller]")]
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IProjectsService _projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpGet]
        public IActionResult Get() => Json(_projectsService.GetAllActive());
    }
}