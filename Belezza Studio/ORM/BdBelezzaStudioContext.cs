using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Belezza_Studio.ORM;

public partial class BdBelezzaStudioContext : DbContext
{
    public BdBelezzaStudioContext()
    {
    }

    public BdBelezzaStudioContext(DbContextOptions<BdBelezzaStudioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAtendimento> TbAtendimentos { get; set; }

    public virtual DbSet<TbServico> TbServicos { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    public virtual DbSet<ViewAtendimento> ViewAtendimentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAB205_13\\SQLEXPRESS;Database=Belezza_Studio;User Id=Suuh;Password=su&len123;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAtendimento>(entity =>
        {
            entity.ToTable("Tb_Atendimento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtHoraAgendamento).HasColumnType("datetime");
            entity.Property(e => e.FkServico).HasColumnName("fk_Servico");
            entity.Property(e => e.FkUsuarioId).HasColumnName("fk_Usuario_ID");

            entity.HasOne(d => d.FkServicoNavigation).WithMany(p => p.TbAtendimentos)
                .HasForeignKey(d => d.FkServico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tb_Atendimento_Tb_Servico");

            entity.HasOne(d => d.FkUsuario).WithMany(p => p.TbAtendimentos)
                .HasForeignKey(d => d.FkUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tb_Atendimento_Tb_Usuario");
        });

        modelBuilder.Entity<TbServico>(entity =>
        {
            entity.ToTable("Tb_Servico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TipoServico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.ToTable("Tb_Usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ViewAtendimento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Atendimento");

            entity.Property(e => e.DtHoraAgendamento).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoServico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
