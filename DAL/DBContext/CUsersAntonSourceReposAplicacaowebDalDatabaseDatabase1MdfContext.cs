using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MODEL;

public partial class CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext : DbContext
{
    public CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext()
    {
    }

    public CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext(DbContextOptions<CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbMatch> TbMatches { get; set; }

    public virtual DbSet<TbPlayer> TbPlayers { get; set; }

    public virtual DbSet<TbPlayerInMatch> TbPlayerInMatches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename = C:\\Users\\anton\\source\\repos\\AplicacaoWeb\\DAL\\database\\Database1.mdf;Integrated Security= True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbMatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tb_Match__3214EC0785E2B84A");

            entity.ToTable("Tb_Match");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbPlayer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tb_Playe__3214EC07B495EB23");

            entity.ToTable("Tb_Player");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Mmr).HasColumnName("MMR");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbPlayerInMatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tb_Playe__3214EC075FF1CBA1");

            entity.ToTable("Tb_PlayerInMatch");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
