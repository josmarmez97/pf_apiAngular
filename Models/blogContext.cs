using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace proyecto_final.Models
{
    public partial class blogContext : DbContext
    {
        public blogContext()
        {
        }

        public blogContext(DbContextOptions<blogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=blog;Userid=postgres;Password=3E84F243D0;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comentarios>(entity =>
            {
                entity.HasKey(e => e.id_com)
                    .HasName("comentarios_pkey");

                entity.ToTable("comentarios");

                entity.Property(e => e.id_com).HasColumnName("id_com");

                entity.Property(e => e.comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("character varying");

                entity.Property(e => e.id_usuarios).HasColumnName("id_usuarios");

                entity.Property(e => e.t_com)
                    .IsRequired()
                    .HasColumnName("t_com")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.id_roles)
                    .HasName("roles_pkey");

                entity.ToTable("roles");

                entity.Property(e => e.id_roles)
                    .HasColumnName("id_roles")
                    .ValueGeneratedNever();

                entity.Property(e => e.nombre_rol)
                    .IsRequired()
                    .HasColumnName("nombre_rol")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.id_usuario)
                    .HasName("usuarios_pkey");

                entity.ToTable("usuarios");

                entity.Property(e => e.id_usuario).HasColumnName("id_usuario");

                entity.Property(e => e.id_rol).HasColumnName("id_rol");

                entity.Property(e => e.pass)
                    .HasColumnName("pass")
                    .HasColumnType("character varying");

                entity.Property(e => e.userid)
                    .IsRequired()
                    .HasColumnName("userid")
                    .HasColumnType("character varying");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
