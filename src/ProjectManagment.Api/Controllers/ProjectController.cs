using Microsoft.AspNetCore.Mvc;
using ProjectManagment.Business.Dtos;
using ProjectManagment.Business.Project;

namespace ProjectManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects(CancellationToken cancellationToken)
        {
            return Ok(await _projectService.GetAllAsync(cancellationToken));
        }
        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectDto projectDto , CancellationToken cancellationToken)
        {
            await _projectService.AddAsync(projectDto, cancellationToken);

            return Ok();
        }


    }
}
