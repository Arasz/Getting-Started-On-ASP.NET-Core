using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public IList<ProjectDto> GetAllActive() => _applicationDbContext.Projects
            .Where(project => project.IsDeleted == false)
            .Select(Map)
            .ToList();

        public ProjectDto GetById(int id)
        {
            var project = _applicationDbContext.Projects
                .SingleOrDefault(pro => pro.Id == id);

            return Map(project);
        }

        public void Add(AddProjectDto project)
        {
            var newProject = new Project
            {
                Name = project.Name,
                Description = project.Description,
                CreationDate = DateTime.Now
            };

            _applicationDbContext.Projects.Add(newProject);
            _applicationDbContext.SaveChanges();
        }

        public ProjectDto GetByName(string projectName)
        {
            var existingProject = _applicationDbContext.Projects.FirstOrDefault(project => project.Name == projectName);

            if (existingProject is null)
                return null;

            return Map(existingProject);
        }

        private  ProjectDto Map(Project project) => new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreationDate = project.CreationDate,
            IsDeleted = project.IsDeleted,
        };
    }
}