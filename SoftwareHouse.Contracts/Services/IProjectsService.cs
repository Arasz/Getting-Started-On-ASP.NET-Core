using System.Collections.Generic;
using SoftwareHouse.Contracts.Common;
using SoftwareHouse.Contracts.DataContracts;

namespace SoftwareHouse.Contracts.Services
{
    public interface IProjectsService
    {
        IList<ProjectDto> GetAllActive();

        CommonResult<ProjectDto> GetById(int id);
    }
}