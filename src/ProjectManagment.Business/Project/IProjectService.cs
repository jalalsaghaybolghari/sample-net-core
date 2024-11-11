using ProjectManagment.Business.Dtos;

namespace ProjectManagment.Business.Project;

public interface IProjectService
{
    Task<List<ProjectDto>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(ProjectDto projectDto, CancellationToken cancellationToken);
    Task<ProjectDto> GetByIdAsync(int id, CancellationToken cancellationToken)
}
