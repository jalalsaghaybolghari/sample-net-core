using Microsoft.EntityFrameworkCore;
using ProjectManagment.Business.Dtos;
using ProjectManagment.Business.Exceptions;
using ProjectManagment.Business.Mapper;
using ProjectManagment.Domain.DbContext;

namespace ProjectManagment.Business.Project;
public class ProjectService: IProjectService
{
    private readonly ProjectDbContext _projectDbContext;
    public ProjectService(ProjectDbContext projectDbContext)
    {
        _projectDbContext = projectDbContext;
    }

    /// <summary>
    /// return project list
    /// </summary>
    /// <returns></returns>
    public async Task<List<ProjectDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var projects = await _projectDbContext.projects.ToListAsync();
        List<ProjectDto> projectDtoList = new();

        foreach (var project in projects)
        {
            var mappedProject = Mapper<ProjectDto, Domain.Entities.Project>.MappClasses(project);
            projectDtoList.Add(mappedProject);
        }
        
        return projectDtoList;
    }

    /// <summary>
    /// return project 
    /// </summary>
    /// <returns></returns>
    public async Task<ProjectDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var project = await _projectDbContext.projects.SingleOrDefaultAsync(x => x.Id == id , cancellationToken);
        if (project == null)
            throw new NotFoundException("Project Not found");

        var mappedProject = Mapper<ProjectDto, Domain.Entities.Project>.MappClasses(project);
        return mappedProject;

    }

    /// <summary>
    /// add new project
    /// </summary>
    /// <returns></returns>
    public async Task AddAsync(ProjectDto projectDto, CancellationToken cancellationToken)
    {
        var projectMaped = Mapper<Domain.Entities.Project, ProjectDto>.MappClasses(projectDto);
        projectMaped.CreatedDate = DateTime.UtcNow;
        await _projectDbContext.projects.AddAsync(projectMaped, cancellationToken);
        await _projectDbContext.SaveChangesAsync(cancellationToken);

    }
}
