using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Empleados.Api.Models;

public partial class EmpleadosContext : DbContext
{
    public EmpleadosContext()
    {
    }

    public EmpleadosContext(DbContextOptions<EmpleadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.ToTable("Departamento");

            entity.Property(e => e.FechaDeRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.ToTable("Empleado");

            entity.Property(e => e.FechaDeContrato).HasColumnType("datetime");
            entity.Property(e => e.FechaDeRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Departamento).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.DepartamentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado_Departamento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
