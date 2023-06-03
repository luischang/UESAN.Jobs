﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Infrastructure.Models;

public partial class BolsaDeTrabajoContext : DbContext
{
    public BolsaDeTrabajoContext()
    {
    }

    public BolsaDeTrabajoContext(DbContextOptions<BolsaDeTrabajoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empresa> Empresa { get; set; }

    public virtual DbSet<Oferta> Oferta { get; set; }

    public virtual DbSet<OfertaPostular> OfertaPostular { get; set; }

    public virtual DbSet<Postulante> Postulante { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-HP1HJ343\\SOY_YO;DataBase=Bolsa_de_trabajo;TrustServerCertificate=True;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__Empresa__75D2CED4BCA0C362");

            entity.Property(e => e.IdEmpresa)
                .ValueGeneratedNever()
                .HasColumnName("idEmpresa");
            entity.Property(e => e.Direccion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ruc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RUC");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Empresa)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Empresa__idUsuar__29572725");
        });

        modelBuilder.Entity<Oferta>(entity =>
        {
            entity.HasKey(e => e.IdOferta).HasName("PK__Oferta__05A1245E537704F3");

            entity.Property(e => e.IdOferta)
                .ValueGeneratedNever()
                .HasColumnName("idOferta");
            entity.Property(e => e.Certificados)
                .HasColumnType("image")
                .HasColumnName("certificados");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.Funciones)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("funciones");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.Modalidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modalidad");
            entity.Property(e => e.Puesto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("puesto");
            entity.Property(e => e.Requisitos)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("requisitos");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Oferta)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK__Oferta__idEmpres__2C3393D0");
        });

        modelBuilder.Entity<OfertaPostular>(entity =>
        {
            entity.HasKey(e => e.IdOfertaPostular).HasName("PK__OfertaPo__2DB5694C4617202E");

            entity.Property(e => e.IdOfertaPostular)
                .ValueGeneratedNever()
                .HasColumnName("idOfertaPostular");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdOferta).HasColumnName("idOferta");
            entity.Property(e => e.IdPostulante).HasColumnName("idPostulante");

            entity.HasOne(d => d.IdOfertaNavigation).WithMany(p => p.OfertaPostular)
                .HasForeignKey(d => d.IdOferta)
                .HasConstraintName("idOferta");

            entity.HasOne(d => d.IdPostulanteNavigation).WithMany(p => p.OfertaPostular)
                .HasForeignKey(d => d.IdPostulante)
                .HasConstraintName("idPostulante");
        });

        modelBuilder.Entity<Postulante>(entity =>
        {
            entity.HasKey(e => e.IdPostulante).HasName("PK__Postulan__D8831F4DA0226515");

            entity.Property(e => e.IdPostulante).ValueGeneratedNever();
            entity.Property(e => e.Certificados)
                .HasColumnType("image")
                .HasColumnName("certificados");
            entity.Property(e => e.Cv)
                .HasColumnType("image")
                .HasColumnName("CV");
            entity.Property(e => e.Direccion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Postulante)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Postulant__idUsu__267ABA7A");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6C3E13E51");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("idUsuario");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}