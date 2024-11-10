using System.ComponentModel.DataAnnotations;

namespace ProjectManagment.Domain.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }

}
