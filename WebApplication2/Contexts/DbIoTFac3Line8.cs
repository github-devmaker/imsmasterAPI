using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using imsmasterApi.Models;

namespace imsmasterApi.Contexts;

public partial class DbIoTFac3Line8 : DbContext
{
    public DbIoTFac3Line8()
    {
    }

    public DbIoTFac3Line8(DbContextOptions<DbIoTFac3Line8> options)
        : base(options)
    {
    }

    public virtual DbSet<McEtdGroupRank> McEtdGroupRanks { get; set; }

    public virtual DbSet<McEtdModelDetail> McEtdModelDetails { get; set; }

    public virtual DbSet<McEtdMstModel> McEtdMstModels { get; set; }

    public virtual DbSet<McEtdMstPart> McEtdMstParts { get; set; }

    public virtual DbSet<McEtdMstPartType> McEtdMstPartTypes { get; set; }

    public virtual DbSet<McEtdMstProgram> McEtdMstPrograms { get; set; }

    public virtual DbSet<McEtdMstRank> McEtdMstRanks { get; set; }

    public virtual DbSet<McEtdProgramDetail> McEtdProgramDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.194.122.103;Database=ETD_FAC3_PH2;TrustServerCertificate=True;uid=sa;password=decjapan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<McEtdGroupRank>(entity =>
        {
            entity.HasKey(e => e.GId);

            entity.ToTable("MC_etd_group_rank");

            entity.Property(e => e.GId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("g_id");
            entity.Property(e => e.RId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("r_id");
            entity.Property(e => e.RName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("r_name");
        });

        modelBuilder.Entity<McEtdModelDetail>(entity =>
        {
            entity.HasKey(e => new { e.MId, e.PId, e.PtId });

            entity.ToTable("MC_etd_model_detail");

            entity.Property(e => e.MId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("m_id");
            entity.Property(e => e.PId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("p_id");
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pt_id");
            entity.Property(e => e.PCycletime).HasColumnName("p_cycletime");
            entity.Property(e => e.PDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("p_date");
            entity.Property(e => e.PMaxDimension).HasColumnName("p_max_dimension");
            entity.Property(e => e.PMidDimension).HasColumnName("p_mid_dimension");
            entity.Property(e => e.PMinDimension).HasColumnName("p_min_dimension");
            entity.Property(e => e.PStatus).HasColumnName("p_status");
            entity.Property(e => e.PUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("p_user");
            entity.Property(e => e.RId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("r_id");
        });

        modelBuilder.Entity<McEtdMstModel>(entity =>
        {
            entity.HasKey(e => e.MId);

            entity.ToTable("MC_etd_mst_model");

            entity.Property(e => e.MId)
                .HasMaxLength(20)
                .HasColumnName("m_id");
            entity.Property(e => e.MDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("m_date");
            entity.Property(e => e.MName)
                .HasMaxLength(50)
                .HasColumnName("m_name");
            entity.Property(e => e.MUser)
                .HasMaxLength(50)
                .HasColumnName("m_user");
        });

        modelBuilder.Entity<McEtdMstPart>(entity =>
        {
            entity.HasKey(e => e.PId);

            entity.ToTable("MC_etd_mst_part");

            entity.Property(e => e.PId)
                .ValueGeneratedNever()
                .HasColumnName("p_id");
            entity.Property(e => e.PName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("p_name");
        });

        modelBuilder.Entity<McEtdMstPartType>(entity =>
        {
            entity.HasKey(e => e.PtId);

            entity.ToTable("MC_etd_mst_part_type");

            entity.Property(e => e.PtId)
                .ValueGeneratedNever()
                .HasColumnName("pt_id");
            entity.Property(e => e.PtName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pt_name");
        });

        modelBuilder.Entity<McEtdMstProgram>(entity =>
        {
            entity.HasKey(e => e.ProId);

            entity.ToTable("MC_etd_mst_program");

            entity.Property(e => e.ProId)
                .ValueGeneratedNever()
                .HasColumnName("pro_id");
            entity.Property(e => e.ProName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pro_name");
            entity.Property(e => e.Yc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("yc");
        });

        modelBuilder.Entity<McEtdMstRank>(entity =>
        {
            entity.HasKey(e => e.RId);

            entity.ToTable("MC_etd_mst_rank");

            entity.Property(e => e.RId)
                .ValueGeneratedNever()
                .HasColumnName("r_id");
            entity.Property(e => e.RColor)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("r_color");
            entity.Property(e => e.RName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("r_name");
        });

        modelBuilder.Entity<McEtdProgramDetail>(entity =>
        {
            entity.HasKey(e => e.MId);

            entity.ToTable("MC_etd_program_detail");

            entity.Property(e => e.MId)
                .HasMaxLength(20)
                .HasColumnName("m_id");
            entity.Property(e => e.ProId).HasColumnName("pro_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
