using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TCS_Employee_DbFirst_Approach.DbConnect;

public partial class TcsEmployeeEntityCodeFirstApproachContext : DbContext
{
    public TcsEmployeeEntityCodeFirstApproachContext()
    {
    }

    public TcsEmployeeEntityCodeFirstApproachContext(DbContextOptions<TcsEmployeeEntityCodeFirstApproachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departement> Departements { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Orderss> Ordersses { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-LNEME22;Database=TCS_Employee_Entity_CodeFirstApproach;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departement>(entity =>
        {
            entity.HasKey(e => e.Deptid);

            entity.ToTable("departements");

            entity.Property(e => e.Deptid).HasColumnName("deptid");
            entity.Property(e => e.Deptlocation).HasColumnName("deptlocation");
            entity.Property(e => e.Deptname).HasColumnName("deptname");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empid);

            entity.ToTable("employees");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Empname).HasColumnName("empname");
            entity.Property(e => e.Empsalary).HasColumnName("empsalary");
        });

        modelBuilder.Entity<Orderss>(entity =>
        {
            entity.HasKey(e => e.Orderid);

            entity.ToTable("orderss");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Orderlocation).HasColumnName("orderlocation");
            entity.Property(e => e.Ordername).HasColumnName("ordername");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
