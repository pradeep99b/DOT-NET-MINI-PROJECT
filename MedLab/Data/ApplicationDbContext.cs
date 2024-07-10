using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MedLab.Models;

namespace MedLab.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MedLab.Models.Appointment> Appointment { get; set; } = default!;
        public DbSet<MedLab.Models.Billing> Billing { get; set; } = default!;
        public DbSet<MedLab.Models.City> City { get; set; } = default!;
        public DbSet<MedLab.Models.Department> Department { get; set; } = default!;
        public DbSet<MedLab.Models.LabAssistant> LabAssistant { get; set; } = default!;
        public DbSet<MedLab.Models.State> State { get; set; } = default!;
        public DbSet<MedLab.Models.Test> Test { get; set; } = default!;
        public DbSet<MedLab.Models.User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.State)
                .WithMany()
                .HasForeignKey(u => u.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.City)
                .WithMany()
                .HasForeignKey(u => u.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Test>()
            .HasOne(t => t.Department)
            .WithMany(d => d.Tests)
            .HasForeignKey(t => t.DepartmentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
      
 
