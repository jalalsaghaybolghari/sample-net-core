using Moq;
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


}