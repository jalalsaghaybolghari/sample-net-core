namespace ProjectManagment.Domain.Entities;

public class Project : BaseEntity
{
    public string ProjectName { get; set; } 
    public int? ProjectVersion { get; set; }
    public DateTime StartDate { get; set; }
}
