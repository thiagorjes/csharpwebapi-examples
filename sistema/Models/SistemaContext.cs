using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sistema.Models
{
    public partial class SistemaContext : DbContext
    {
        public SistemaContext()
        {
        }

        public SistemaContext(DbContextOptions<SistemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessToken> AccessToken { get; set; }
        public virtual DbSet<EntidadeAutenticadora> EntidadeAutenticadora { get; set; }
        public virtual DbSet<PessoaFisica> PessoaFisica { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Name=ConnectionStrings.Sistema");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessToken>(entity =>
            {
                entity.HasKey(e => e.IdAccessToken);

                entity.ToTable("AccessToken", "Sistema");

                entity.HasIndex(e => e.Origem)
                    .HasName("FK_ea_idx");

                entity.HasIndex(e => e.PessoaFisica)
                    .HasName("FK_pf_idx");

                entity.Property(e => e.IdAccessToken).HasColumnType("int(11)");

                entity.Property(e => e.AccessToken1)
                    .IsRequired()
                    .HasColumnName("AccessToken")
                    .HasColumnType("blob");

                entity.Property(e => e.CriadoEm).HasColumnType("date");

                entity.Property(e => e.Origem).HasColumnType("int(11)");

                entity.Property(e => e.PessoaFisica).HasColumnType("int(11)");

                entity.Property(e => e.Validade).HasColumnType("date");

                entity.HasOne(d => d.OrigemNavigation)
                    .WithMany(p => p.AccessToken)
                    .HasForeignKey(d => d.Origem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ea");

                entity.HasOne(d => d.PessoaFisicaNavigation)
                    .WithMany(p => p.AccessToken)
                    .HasForeignKey(d => d.PessoaFisica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pf");
            });

            modelBuilder.Entity<EntidadeAutenticadora>(entity =>
            {
                entity.HasKey(e => e.IdEntidadeAutenticadora);

                entity.ToTable("EntidadeAutenticadora", "Sistema");

                entity.Property(e => e.IdEntidadeAutenticadora).HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PessoaFisica>(entity =>
            {
                entity.HasKey(e => e.IdPessoaFisica);

                entity.ToTable("PessoaFisica", "Sistema");

                entity.Property(e => e.IdPessoaFisica).HasColumnType("int(11)");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Maior).HasColumnType("tinyint(4)");

                entity.Property(e => e.Nascimento).HasColumnType("date");

                entity.Property(e => e.NickName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });
        }
    }
}
