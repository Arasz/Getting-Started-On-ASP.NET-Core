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

        public CommonResult SoftlyDelete(int projectId)
        {
            if(!_projectsRepository.Exist(projectId))
                return CommonResult.Failure("Project with given id doesn't exist");

            _projectsRepository.SoftDelete(projectId);
            return CommonResult.Success();
        }

        public IList<ProjectDto> GetAllActive() => _projectsRepository.GetAllActive();

        public CommonResult<ProjectDto> GetById(int id)
        {
            var project = _projectsRepository.GetById(id);

            if (project == null || project.IsDeleted)
                return CommonResult<ProjectDto>.Failure("Problem occured during fetching project with given id");

            return CommonResult<ProjectDto>.Success(project);
        }

        public CommonResult Add(AddProjectDto project)
        {
            //TODO: Move validation to separate class (for now I am keeping it as simple as possible)
            if(string.IsNullOrEmpty(project.Name))
                return CommonResult.Failure("Cannot create project without name");
            if(string.IsNullOrEmpty(project.Description))
                return CommonResult.Failure("Cannot create project without description");

            var existingProject = _projectsRepository.GetByName(project.Name);

            if(existingProject != null && !existingProject.IsDeleted)
                return CommonResult.Failure("Project with given name already exist");

            _projectsRepository.Add(project);

            return CommonResult.Success();
        }
    }
}