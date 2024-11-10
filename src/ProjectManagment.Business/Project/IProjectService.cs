using ProjectManagment.Business.Dtos;

namespace ProjectManagment.Business.Project;

public interface IProjectService
{
    Task<List<ProjectDto>> GetAllAsync(CancellationToken cancellationToken);
}
