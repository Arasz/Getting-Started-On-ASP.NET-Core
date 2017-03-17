using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SoftwareHouse.Contracts.DataContracts;
using SoftwareHouse.Contracts.Repositories;
using SoftwareHouse.DataAccess.Models;

namespace SoftwareHouse.DataAccess.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProjectsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

            //TODO : Move automaper intialization to bootstraper
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectDto>());
        }

        public IList<ProjectDto> GetAllActive() => _applicationDbContext.Projects
            .Where(project => project.IsDeleted == false)
            .Select(Mapper.Map<Project, ProjectDto>)
            .ToList();

        public ProjectDto GetById(int id)
        {
            var project = _applicationDbContext.Projects
                .SingleOrDefault(pro => pro.Id == id);

            return Mapper.Map<Project, ProjectDto>(project);
        }
    }
}