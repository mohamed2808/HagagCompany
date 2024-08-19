using System;
using System.Collections.Generic;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HagagCompany.Entities;

public partial class HagagCompanyContext : DbContext
{
    public HagagCompanyContext()
    {
    }

    public HagagCompanyContext(DbContextOptions<HagagCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-AAT1VEH;Database=HagagCompany;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            modelBuilder.Entity<Employee>()
          .HasKey(e => e.EmpolyeeId);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpolyeeId)
                .ValueGeneratedOnAdd();
            entity.HasKey(e => e.EmpolyeeId).HasName("PK__Employee__D86EFD0665445ADE");

            entity.HasIndex(e => e.Number, "UQ__Employee__3214EC263AE63FC6").IsUnique();

            entity.HasIndex(e => e.EmailId, "UQ__Employee__7ED91AEE9F08D90E").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__Employee__85FB4E38AEA842F6").IsUnique();

            entity.Property(e => e.EmpolyeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmpolyeeID");
            entity.Property(e => e.EmailId)
                .HasMaxLength(30)
                .HasColumnName("EmailID");
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.Number).HasColumnName("ID");
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.JoiningDate).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(15);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("EmpolyeeJop_FK");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__Jobs__056690E240B58DD3");

            entity.Property(e => e.JobId)
                .ValueGeneratedNever()
                .HasColumnName("JobID");
            entity.Property(e => e.JobName).HasMaxLength(20);
          
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => new { e.UserName, e.Password }).HasName("Log_Pk");

            entity.Property(e => e.UserName).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
