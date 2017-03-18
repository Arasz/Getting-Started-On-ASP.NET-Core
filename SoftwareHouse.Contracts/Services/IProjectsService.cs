using System.Collections.Generic;
using SoftwareHouse.Contracts.Common;
using SoftwareHouse.Contracts.DataContracts;

namespace SoftwareHouse.Contracts.Services
{
    public interface IProjectsService
    {
        CommonResult SoftlyDelete(int projectId);

        IList<ProjectDto> GetAllActive();

        CommonResult<ProjectDto> GetById(int id);

        CommonResult Add(AddProjectDto project);
    }
}