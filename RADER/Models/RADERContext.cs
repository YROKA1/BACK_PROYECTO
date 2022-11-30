using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RADER.Models
{
    public partial class RADERContext : DbContext
    {
        public RADERContext()
            
        {
        }

        public RADERContext(DbContextOptions<RADERContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alertum> Alerta { get; set; } = null!;
        public virtual DbSet<Componente> Componentes { get; set; } = null!;
        public virtual DbSet<Dispositivo> Dispositivos { get; set; } = null!;
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Historial> Historials { get; set; } = null!;
        public virtual DbSet<Perfil> Perfils { get; set; } = null!;
        public virtual DbSet<Sugerencium> Sugerencia { get; set; } = null!;
        public virtual DbSet<Usuario> Usuario { get; set; } = null!;

        public virtual DbSet<Archivos> Archivos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-759APQ2\\SQLEXPRESS; Database=RADER; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alertum>(entity =>
            {
                entity.HasKey(e => e.IdAlerta);

                entity.Property(e => e.IdAlerta).HasColumnName("id_alerta");

                entity.Property(e => e.IdHistorial).HasColumnName("id_historial");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.TipoAlerta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo_alerta");

           
            });

            modelBuilder.Entity<Componente>(entity =>
            {
                entity.HasKey(e => e.IdComponente);

                entity.ToTable("Componente");

                entity.Property(e => e.IdComponente).HasColumnName("id_componente");

                entity.Property(e => e.DescripcionComponente)
                    .HasColumnType("text")
                    .HasColumnName("descripcion_componente");

                entity.Property(e => e.FechacompraComponente)
                    .HasColumnType("date")
                    .HasColumnName("fechacompra_componente");

                entity.Property(e => e.FinvidautilComponente)
                    .HasColumnType("date")
                    .HasColumnName("finvidautil_componente");

                entity.Property(e => e.IdDispositivo).HasColumnName("id_dispositivo");

                entity.Property(e => e.NombreComponente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_componente");

            });

            modelBuilder.Entity<Dispositivo>(entity =>
            {
                entity.HasKey(e => e.IdDispositivo);

                entity.ToTable("Dispositivo");

                entity.Property(e => e.IdDispositivo).HasColumnName("id_dispositivo");

                entity.Property(e => e.AltoDispositivo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alto_dispositivo");

                entity.Property(e => e.AnchoDispositivo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ancho_dispositivo");

                entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

                entity.Property(e => e.LargoDispositivo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("largo_dispositivo");

                entity.Property(e => e.NombreDispositivo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_dispositivo");

                entity.Property(e => e.PesoDispositivo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("peso_dispositivo");

            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.ToTable("Empresa");

                entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

                entity.Property(e => e.DireccionEmpresa)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("direccion_empresa");

                entity.Property(e => e.LocalidadEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("localidad_empresa");

                entity.Property(e => e.RazonsocialEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("razonsocial_empresa");

                entity.Property(e => e.TelefonoEmpresa)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefono_empresa");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.ToTable("Estado");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.DescripcionEstado)
                    .HasColumnType("text")
                    .HasColumnName("descripcion_estado");

                entity.Property(e => e.NombreEstado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_estado");
                entity.Property(e => e.Acciones)
                   .HasMaxLength(50)
                   .IsUnicode(false)
                   .HasColumnName("Acciones");
            });

            modelBuilder.Entity<Historial>(entity =>
            {
                entity.HasKey(e => e.IdHistorial);

                entity.ToTable("Historial");

                entity.Property(e => e.IdHistorial).HasColumnName("id_historial");

                entity.Property(e => e.FechaNovedad)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_novedad");

                entity.Property(e => e.IdComponente).HasColumnName("id_componente");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NovedadComponente)
                    .HasColumnType("text")
                    .HasColumnName("novedad_componente");

                entity.Property(e => e.SugerenciaUsuario)
                    .HasColumnType("text")
                    .HasColumnName("sugerencia_usuario");

            
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.ToTable("Perfil");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.DescripcionPerfil)
                    .HasColumnType("text")
                    .HasColumnName("descripcion_perfil");

                entity.Property(e => e.NombrePerfil)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_perfil");
            });

            modelBuilder.Entity<Sugerencium>(entity =>
            {
                entity.HasKey(e => e.IdSugerencia);

                entity.Property(e => e.IdSugerencia).HasColumnName("id_sugerencia");

                entity.Property(e => e.DescripcionSugerencia)
                    .HasColumnType("text")
                    .HasColumnName("descripcion_sugerencia");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

          
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.ClaveUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("clave_usuario");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre_usuario");

            });
            modelBuilder.Entity<Archivos>(entity =>
            {
                entity.HasKey(e => e.IdArchivo);

                entity.ToTable("Archivos");

                entity.Property(e => e.IdArchivo).HasColumnName("id_archivo");

                entity.Property(e => e.NombreArchivo)
                    .HasMaxLength(50)
                    .HasColumnName("nombre_archivo");

                entity.Property(e => e.ExtensionArchivo)
                    .HasMaxLength(10)
                    .HasColumnName("extension_archivo");

                entity.Property(e => e.CapacidadArchivo)
                    .HasColumnType("float")
                    .HasColumnName("capacidad_archivo");

                entity.Property(e => e.UbicacionArchivo)
                    .HasColumnType("text")
                    .HasColumnName("ubicacion_archivo");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
