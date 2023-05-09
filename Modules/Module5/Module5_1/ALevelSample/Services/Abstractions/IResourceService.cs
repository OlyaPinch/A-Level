using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Dtos;

namespace ALevelSample.Services.Abstractions;

public interface IResourceService
{
    Task<ResourceDto> GetResourceById(int id);
    Task<List<ResourceDto>> GetResources(int page);
}