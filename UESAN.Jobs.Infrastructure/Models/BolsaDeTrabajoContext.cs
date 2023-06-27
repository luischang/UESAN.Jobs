using System;
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

    public virtual DbSet<Archivos> Archivos { get; set; }

    public virtual DbSet<Calificaciones> Calificaciones { get; set; }

    public virtual DbSet<Competencias> Competencias { get; set; }

    public virtual DbSet<CompetenciasOferta> CompetenciasOferta { get; set; }

    public virtual DbSet<CompetenciasPostulante> CompetenciasPostulante { get; set; }

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
        modelBuilder.Entity<Archivos>(entity =>
        {
            entity.HasKey(e => e.IdArchivo).HasName("PK__Archivos__26B92111D05D2D1B");

            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdPostulanteNavigation).WithMany(p => p.Archivos)
                .HasForeignKey(d => d.IdPostulante)
                .HasConstraintName("FK__Archivos__IdPost__35BCFE0A");
        });

        modelBuilder.Entity<Calificaciones>(entity =>
        {
            entity.HasKey(e => e.IdCalificacion).HasName("PK__Califica__E056358F3D52B914");

            entity.Property(e => e.IdCalificacion).HasColumnName("idCalificacion");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__idEmp__36B12243");

            entity.HasOne(d => d.IdPostulanteNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.IdPostulante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__IdPos__37A5467C");
        });

        modelBuilder.Entity<Competencias>(entity =>
        {
            entity.HasKey(e => e.IdCompetencia).HasName("PK__Competen__DA802ADD9D11005B");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<CompetenciasOferta>(entity =>
        {
            entity.HasKey(e => e.IdCompetenciaOferta).HasName("PK__Competen__65E5E3387F0B935F");

            entity.HasOne(d => d.IdCompetenciaNavigation).WithMany(p => p.CompetenciasOferta)
                .HasForeignKey(d => d.IdCompetencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Competenc__IdCom__38996AB5");

            entity.HasOne(d => d.IdOfertaNavigation).WithMany(p => p.CompetenciasOferta)
                .HasForeignKey(d => d.IdOferta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Competenc__IdOfe__398D8EEE");
        });

        modelBuilder.Entity<CompetenciasPostulante>(entity =>
        {
            entity.HasKey(e => e.IdCompetenciaPostulante).HasName("PK__Competen__5BBD3E38225EB915");

            entity.HasOne(d => d.IdCompetenciaNavigation).WithMany(p => p.CompetenciasPostulante)
                .HasForeignKey(d => d.IdCompetencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Competenc__IdCom__3A81B327");

            entity.HasOne(d => d.IdPostulanteNavigation).WithMany(p => p.CompetenciasPostulante)
                .HasForeignKey(d => d.IdPostulante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Competenc__IdPos__3B75D760");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__Empresa__75D2CED4852E63F7");

            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.Direccion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RUC");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Empresa)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Empresa__idUsuar__3C69FB99");
        });

        modelBuilder.Entity<Oferta>(entity =>
        {
            entity.HasKey(e => e.IdOferta).HasName("PK__Oferta__05A1245EA7856DCB");

            entity.Property(e => e.IdOferta).HasColumnName("idOferta");
            entity.Property(e => e.Certificados)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("certificados");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
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
            entity.Property(e => e.NumeroPostulantes).HasColumnName("numeroPostulantes");
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
                .HasConstraintName("FK__Oferta__idEmpres__3D5E1FD2");
        });

        modelBuilder.Entity<OfertaPostular>(entity =>
        {
            entity.HasKey(e => e.IdOfertaPostular).HasName("PK__OfertaPo__2DB5694C59B6E3D6");

            entity.Property(e => e.IdOfertaPostular).HasColumnName("idOfertaPostular");
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
            entity.HasKey(e => e.IdPostulante).HasName("PK__Postulan__D8831F4D357C9DA9");

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
                .HasConstraintName("FK__Postulant__idUsu__403A8C7D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6AC087C7E");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
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
