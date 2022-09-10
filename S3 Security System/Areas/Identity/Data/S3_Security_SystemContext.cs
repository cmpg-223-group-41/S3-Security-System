using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using S3_Security_System.Areas.Identity.Data;
using S3_Security_System.Models;

namespace S3_Security_System.Data;

public class S3_Security_SystemContext : IdentityDbContext<S3_Security_SystemUser>
{
    public S3_Security_SystemContext(DbContextOptions<S3_Security_SystemContext> options)
        : base(options)
    {
    }

    public DbSet<Staff> Staff { get; set; }

    public DbSet<Student> Students { get; set; }
    public DbSet<Visitor> Visitors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<Breach>()
            .HasOne(p => p.BreachType)
            .WithMany();
    }

    public DbSet<S3_Security_System.Models.Breach>? Breach { get; set; }

    public DbSet<S3_Security_System.Models.BreachType>? BreachType { get; set; }

    public DbSet<S3_Security_System.Models.City>? City { get; set; }

    public DbSet<S3_Security_System.Models.EntranceToken>? EntranceToken { get; set; }

    public DbSet<S3_Security_System.Models.Position>? Position { get; set; }

    public DbSet<S3_Security_System.Models.Province>? Province { get; set; }

    public DbSet<S3_Security_System.Models.Registor>? Registor { get; set; }
}
