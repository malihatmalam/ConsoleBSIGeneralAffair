using System;
using System.Collections.Generic;
using BSIGeneralAffair.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Approval> Approvals { get; set; }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetCategory> AssetCategories { get; set; }

    public virtual DbSet<AssetUser> AssetUsers { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Departement> Departements { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<OfficeLocation> OfficeLocations { get; set; }

    public virtual DbSet<Proposal> Proposals { get; set; }

    public virtual DbSet<ProposalFile> ProposalFiles { get; set; }

    public virtual DbSet<ProposalService> ProposalServices { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<Samurai> Samurais { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Approval>(entity =>
        {
            entity.Property(e => e.ApprovalAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ApprovalReason).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ApprovalStatus).IsFixedLength();
            entity.Property(e => e.ProposalToken).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.ApprovalUser).WithMany(p => p.Approvals).HasConstraintName("FK_Approvals_Users");

            entity.HasOne(d => d.ProposalTokenNavigation).WithMany(p => p.Approvals).HasConstraintName("FK_Approvals_Proposals");
        });

        modelBuilder.Entity<Asset>(entity =>
        {
            entity.Property(e => e.AssetCategoryId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.AssetCondition).HasDefaultValue("New");
            entity.Property(e => e.AssetCost).HasDefaultValue(0m);
            entity.Property(e => e.AssetFactoryNumber).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.AssetNumber).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.AssetProcurementDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.AsssetName).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.BrandId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.AssetCategory).WithMany(p => p.Assets).HasConstraintName("FK_Assets_AssetCategories");

            entity.HasOne(d => d.Brand).WithMany(p => p.Assets).HasConstraintName("FK_Assets_Brands");
        });

        modelBuilder.Entity<AssetCategory>(entity =>
        {
            entity.HasKey(e => e.AssetCategoryId).HasName("PK_AssetCatgories");

            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<AssetUser>(entity =>
        {
            entity.Property(e => e.HandoverDateTime).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Asset).WithMany(p => p.AssetUsers).HasConstraintName("FK_AssetUsers_Assets");

            entity.HasOne(d => d.User).WithMany(p => p.AssetUsers).HasConstraintName("FK_AssetUsers_Users");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(e => e.BrandName).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Departement>(entity =>
        {
            entity.Property(e => e.DepartementId).ValueGeneratedOnAdd();
            entity.Property(e => e.DepartementName).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeIdnumber)
                .HasDefaultValueSql("(NULL)")
                .IsFixedLength();
            entity.Property(e => e.EmployeeBirthDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EmployeeGender)
                .HasDefaultValue("M")
                .IsFixedLength();
            entity.Property(e => e.EmployeeHireDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EmployeeJobTitle).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EmployeeMaritalStatus)
                .HasDefaultValue("S")
                .IsFixedLength();
            entity.Property(e => e.EmployeePositionLevel).HasDefaultValue("Staff");
            entity.Property(e => e.EmployeeSalary).HasDefaultValue(0m);
            entity.Property(e => e.OfficeId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserId).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.Departement).WithMany(p => p.Employees).HasConstraintName("FK_Employees_Departements");

            entity.HasOne(d => d.Office).WithMany(p => p.Employees).HasConstraintName("FK_Employees_OfficeLocation");

            entity.HasOne(d => d.User).WithMany(p => p.Employees).HasConstraintName("FK_Employees_Users");
        });

        modelBuilder.Entity<OfficeLocation>(entity =>
        {
            entity.Property(e => e.OfficeId).ValueGeneratedOnAdd();
            entity.Property(e => e.OfficeName).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdateAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Proposal>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DepartementId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ProposalBudget).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ProposalDescription).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ProposalNegotiationNote).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ProposalRequireDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ProposalStatus)
                .HasDefaultValue("Waiting")
                .IsFixedLength();
            entity.Property(e => e.ProposalType)
                .HasDefaultValue("Procurement")
                .IsFixedLength();
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.VendorId).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.Departement).WithMany(p => p.Proposals).HasConstraintName("FK_Proposals_Departements");

            entity.HasOne(d => d.User).WithMany(p => p.Proposals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proposals_Users");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Proposals)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Proposals_Vendors");
        });

        modelBuilder.Entity<ProposalFile>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProposalFileType).IsFixedLength();

            entity.HasOne(d => d.ProposalTokenNavigation).WithMany(p => p.ProposalFiles).HasConstraintName("FK_ProposalFiles_Proposals");
        });

        modelBuilder.Entity<ProposalService>(entity =>
        {
            entity.Property(e => e.AssetId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ProposalToken).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Asset).WithMany(p => p.ProposalServices).HasConstraintName("FK_ProposalServices_Assets");

            entity.HasOne(d => d.ProposalTokenNavigation).WithMany(p => p.ProposalServices).HasConstraintName("FK_ProposalServices_Proposals");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserFirstName).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserLastName).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserPassword).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserRole).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserToken).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserUsername).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.VendorAddress).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.VendorName).HasDefaultValueSql("(NULL)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
