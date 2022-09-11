using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using S3_Security_System.Areas.Identity.Data;
using S3_Security_System.Models;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace S3_Security_System.Data;

public class S3_Security_SystemContext : IdentityDbContext<S3_Security_SystemUser>
{
    public S3_Security_SystemContext(DbContextOptions<S3_Security_SystemContext> options)
        : base(options)
    {
    }

    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<S3_Security_SystemUser>()
            .HasOne(b => b.Staff)
            .WithOne(i => i.S3_Security_SystemUser)
            .HasForeignKey<Staff>(b => b.S3_Security_SystemUserId);

        builder.Entity<S3_Security_SystemUser>()
            .HasOne(b => b.Student)
            .WithOne(i => i.S3_Security_SystemUser)
            .HasForeignKey<Student>(b => b.S3_Security_SystemUserId);

        builder.Entity<S3_Security_SystemUser>()
            .HasOne(b => b.Visitor)
            .WithOne(i => i.S3_Security_SystemUser)
            .HasForeignKey<Visitor>(b => b.S3_Security_SystemUserId);

        builder.Entity<Staff>()
            .HasOne(p => p.Position)
            .WithMany();

        builder.Entity<Staff>()
            .HasOne(p => p.StaffCity)
            .WithMany();

        builder.Entity<Staff>()
            .HasOne(p => p.StaffProvince)
            .WithMany();

        builder.Entity<Student>()
            .HasOne(p => p.StudentCity)
            .WithMany();

        builder.Entity<Student>()
            .HasOne(p => p.StudentProvince)
            .WithMany();

        builder.Entity<Breach>()
            .HasOne(p => p.BreachType)
            .WithMany();

        builder.Entity<EntranceToken>()
            .HasOne(p => p.S3_Security_SystemUser)
        .WithMany();

        builder.Entity<Registor>()
            .HasMany(b => b.StudentsPresent)
            .WithOne();
    }

    public DbSet<S3_Security_System.Models.Staff>? Staff { get; set; }

    public DbSet<S3_Security_System.Models.Student>? Students { get; set; }
    public DbSet<S3_Security_System.Models.Visitor>? Visitors { get; set; }
    public DbSet<S3_Security_System.Models.Breach>? Breach { get; set; }

    public DbSet<S3_Security_System.Models.BreachType>? BreachType { get; set; }

    public DbSet<S3_Security_System.Models.City>? City { get; set; }

    public DbSet<S3_Security_System.Models.EntranceToken>? EntranceToken { get; set; }

    public DbSet<S3_Security_System.Models.Position>? Position { get; set; }

    public DbSet<S3_Security_System.Models.Province>? Province { get; set; }

    public DbSet<S3_Security_System.Models.Registor>? Registor { get; set; }
}
