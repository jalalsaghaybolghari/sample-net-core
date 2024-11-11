using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectManagment.Business.Dtos;
using ProjectManagment.Business.Exceptions;
using ProjectManagment.Business.Project;

namespace ProjectManagement.UnitTest.Services;

public class ProjectServiceTests
{
    private readonly TestTools _testTools;
    public ProjectServiceTests()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(ProjectServiceTests));
    }

    #region GetAll
    [Fact]
    public async Task GetAll_ShouldHasData()
    {
        ProjectService projectService = new ProjectService(_testTools.ProjectMemoryDbContext);

        var response = await projectService.GetAllAsync(CancellationToken.None);
        Assert.True(response.Any());
    }
    #endregion

    #region GetByIdProject
    [Theory]
    [InlineData(1)]
    public async Task GetByIdProject_WhenEverythingIsOk_ShouldHasData(int id)
    {
        ProjectService projectService = new ProjectService(_testTools.ProjectMemoryDbContext);

        var response = await projectService.GetByIdAsync(id, CancellationToken.None);
        Assert.NotNull(response);
        Assert.Equal(id, response.Id);
        Assert.Equal("Test1", response.ProjectName);
    }

    [Theory]
    [InlineData(0)]
    public async Task GetByIdProject_WhenIdIsNotExist_ShouldBeNull(int id)
    {
        ProjectService projectService = new ProjectService(_testTools.ProjectMemoryDbContext);

        var response = await projectService.GetByIdAsync(id, CancellationToken.None);

        var project = _testTools.ProjectMemoryDbContext.projects.Find(id);
        Assert.Null(project);

        var exception = await Assert.ThrowsAsync<NotFoundException>(() => projectService.GetByIdAsync(id, CancellationToken.None));
        Assert.Equal("Customer", exception.Message);
    }
    #endregion
    #region CreateProject
    [Theory]
    [InlineData("CreateProjectDescription", "CreateProjectTitle", 12)]
    public async Task CreateProject_WhenEverythingIsOk_ShouldBeSucceeded(string title, string description, int version)
    {

        ProjectService projectService = new ProjectService(_testTools.ProjectMemoryDbContext);

        var projectDto = new ProjectDto
        {
            Description = description,
            ProjectName = title,
            ProjectVersion = version,
            StartDate = DateTime.UtcNow
        };

        await projectService.AddAsync(projectDto, CancellationToken.None);
        var createdRow = await _testTools.ProjectMemoryDbContext.projects.Where(x => x.ProjectVersion == 12).FirstOrDefaultAsync();
        Assert.NotNull(createdRow);

        Assert.Equal(title, createdRow.ProjectName);
        Assert.Equal(description, createdRow.Description);
        Assert.Equal(version, createdRow.ProjectVersion);
    }
    #endregion


}