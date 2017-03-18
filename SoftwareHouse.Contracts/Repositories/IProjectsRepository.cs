using System.Collections.Generic;
using SoftwareHouse.Contracts.DataContracts;

namespace SoftwareHouse.Contracts.Repositories
{
    public interface IProjectsRepository
    {
        IList<ProjectDto> GetAllActive();

        ProjectDto GetById(int id);
        void Add(AddProjectDto project);
        ProjectDto GetByName(string projectName);
    }
}