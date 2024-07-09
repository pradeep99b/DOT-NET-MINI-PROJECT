using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MedLab.Models;

namespace MedLab.Models
{
    public partial class MedLabDbContext : DbContext
    {
        public MedLabDbContext()
        {
        }

        public MedLabDbContext(DbContextOptions<MedLabDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<LabAssistant> LabAssistants { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=MedLabDB;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>()
                .HasMany(s => s.Cities)
                .WithOne(c => c.State)
                .HasForeignKey(c => c.StateId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<City>()
                .HasMany(c => c.Patients)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<State>()
                .HasMany(s => s.Patients)
                .WithOne(p => p.State)
                .HasForeignKey(p => p.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Tests)
                .WithOne(t => t.Department)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.LabAssistants)
                .WithOne(l => l.Department)
                .HasForeignKey(l => l.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Department)
                .HasForeignKey(a => a.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LabAssistant>()
                .HasMany(l => l.Appointments)
                .WithOne(a => a.LabAssistant)
                .HasForeignKey(a => a.LabAssistantId)
                .OnDelete(DeleteBehavior.Restrict);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public DbSet<MedLab.Models.Billing> Billing { get; set; } = default!;
    }

}
