using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LocadoraFilmes.Domains
{
    public partial class LocadoraDeFilmesContext : DbContext
    {
        public LocadoraDeFilmesContext()
        {
        }

        public LocadoraDeFilmesContext(DbContextOptions<LocadoraDeFilmesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Filme> Filmes { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Locacao> Locacaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3NMCASR\\SQLEXPRESS;Database=LocadoraDeFilmes;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__D5946642823969CA");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.HasKey(e => e.IdFilme)
                    .HasName("PK__Filmes__6E8F2A76FEE23FE5");

                entity.Property(e => e.AnoLancamento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Resumo).HasColumnType("text");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Filmes)
                    .HasForeignKey(d => d.IdGenero)
                    .HasConstraintName("FK__Filmes__IdGenero__4BAC3F29");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Generos__0F83498812044C6A");

                entity.Property(e => e.NomeGenero)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Locacao>(entity =>
            {
                entity.HasKey(e => e.IdLocacao)
                    .HasName("PK__Locacao__A12B2045AA212AB8");

                entity.ToTable("Locacao");

                entity.Property(e => e.DataRetirada).HasColumnType("date");

                entity.Property(e => e.PrazoDevolucao).HasColumnType("date");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Locacaos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Locacao__IdClien__4E88ABD4");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.Locacaos)
                    .HasForeignKey(d => d.IdFilme)
                    .HasConstraintName("FK__Locacao__IdFilme__4F7CD00D");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__TipoUsua__9E3A29A58758406A");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Usuarios__B7C92638D9464BA2");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Usuarios__IdTipo__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
