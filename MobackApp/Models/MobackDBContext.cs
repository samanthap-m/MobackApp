using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MobackApp.Models
{
    public partial class MobackDBContext : DbContext
    {
        public MobackDBContext()
        {
        }

        public MobackDBContext(DbContextOptions<MobackDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } 
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmployeeModel> EmployeeModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .HasColumnName("department_name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.DateOfJoining).HasColumnName("date_of_joining");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .HasColumnName("employee_name");

                entity.Property(e => e.PhotoFileName)
                    .HasMaxLength(100)
                    .HasColumnName("photo_file_name");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("employee_department_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
