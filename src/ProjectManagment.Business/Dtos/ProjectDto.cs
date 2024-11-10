namespace ProjectManagment.Business.Dtos;

public class ProjectDto
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public int ProjectVersion { get; set; }
    public DateTime? StartDate { get; set; }
}
