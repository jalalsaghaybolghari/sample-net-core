using Microsoft.EntityFrameworkCore;
using ProjectManagment.Domain.DbContext;
using ProjectManagment.Domain.Entities;

namespace ProjectManagement.UnitTest;

public class TestTools
{

    public ProjectDbContext ProjectMemoryDbContext;

    /// <summary>
    /// Initialization
    /// </summary>
    public void Initialize(string testClassName)
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();

        dbContextOptionsBuilder.UseInMemoryDatabase($"ProjectMemoryDbContext_{testClassName}");
        DbContextOptions<ProjectDbContext>? contextOptions = dbContextOptionsBuilder.Options;
        ProjectMemoryDbContext = new ProjectDbContext(contextOptions);
        SeedData();
    }

    /// <summary>
    /// Initializing new data
    /// </summary>
    public void SeedData()
    {
        List<Project> projectList = new List<Project>();
        if (!ProjectMemoryDbContext.projects.Any())
        {
            // Add new project

            for (int i = 1; i <= 3; i++)
            {
                projectList.Add(new Project
                {
                    ProjectName = $"Test{i}",
                    CreatedDate = DateTime.Now,
                    ProjectVersion = i,
                    StartDate = DateTime.Now,
                    Description = $"Test{i}"
                });
            }

            ProjectMemoryDbContext.projects.AddRange(projectList);
        }
        ProjectMemoryDbContext.SaveChangesAsync();

    }

}