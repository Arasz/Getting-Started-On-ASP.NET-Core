using System.Collections.Generic;
using SoftwareHouse.Contracts.Common;
using SoftwareHouse.Contracts.DataContracts;
using SoftwareHouse.Contracts.Repositories;
using SoftwareHouse.Contracts.Services;

namespace SoftwareHouse.Services.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectsRepository _projectsRepository;

        public ProjectsService(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public IList<ProjectDto> GetAllActive() => _projectsRepository.GetAllActive();

        public CommonResult<ProjectDto> GetById(int id)
        {
            var project = _projectsRepository.GetById(id);

            if (project == null || project.IsDeleted)
                return CommonResult<ProjectDto>.Failure("Problem occured during fetching project with given id");

            return CommonResult<ProjectDto>.Success(project);
        }
    }
}