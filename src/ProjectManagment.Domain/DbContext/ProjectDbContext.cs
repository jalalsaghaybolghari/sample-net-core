namespace ProjectManagment.Domain.DbContext;

using Microsoft.EntityFrameworkCore;
using ProjectManagment.Domain.Entities;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
    {

    }

    public DbSet<Project> projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Project>().ToTable(nameof(Project)).HasKey(p => p.Id);
        modelBuilder.Entity<Project>().Property(p => p.ProjectName).HasMaxLength(150);


        base.OnModelCreating(modelBuilder);
    }
}
