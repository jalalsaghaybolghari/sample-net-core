﻿using Microsoft.EntityFrameworkCore;
using ProjectManagment.Business.Dtos;
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

}