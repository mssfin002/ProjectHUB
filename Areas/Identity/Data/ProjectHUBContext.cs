using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectHUB.Areas.Identity.Data;
using ProjectHUB.Models;

namespace ProjectHUB.Data;

public class ProjectHUBContext : IdentityDbContext<ProjectHUBUser, IdentityRole, string>
{
    public ProjectHUBContext(DbContextOptions<ProjectHUBContext> options)
        : base(options)
    {
    }

    public DbSet<ThemeModel> Themes { get; set; }
    public DbSet<TopicModel> Topics { get; set; }
    public DbSet<AOKModel> AreasOfKnowledge { get; set; }
 //   public DbSet<UploadedFile> UploadedFiles { get; set; }  
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ProjectHUBuserentityconfig());

        /*
            builder.Entity<IdentityRole>().HasData(
           new IdentityRole() {Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
          new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Mentor", NormalizedName = "MENTOR", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Post-GradStudent", NormalizedName = "POST-GRADSTUDENT", ConcurrencyStamp = Guid.NewGuid().ToString() },
             new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Student", NormalizedName = "STUDENT", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Unassigned", NormalizedName = "UNASSIGNED", ConcurrencyStamp = Guid.NewGuid().ToString() },
          new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Expert", NormalizedName = "EXPERT", ConcurrencyStamp = Guid.NewGuid().ToString() }
            );
        */
    }

    public class ProjectHUBuserentityconfig : IEntityTypeConfiguration<ProjectHUBUser>
    {
        public void Configure(EntityTypeBuilder<ProjectHUBUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(455);
            builder.Property(u => u.DateCreated).HasDefaultValue(DateTime.Now);
        }
    }

}
