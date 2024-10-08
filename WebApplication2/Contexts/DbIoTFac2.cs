﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Contexts;

public partial class DbIoTFac2 : DbContext
{
    public DbIoTFac2()
    {
    }

    public DbIoTFac2(DbContextOptions<DbIoTFac2> options)
        : base(options)
    {
    }

    public virtual DbSet<EtdGroupRank> EtdGroupRanks { get; set; }

    public virtual DbSet<EtdModelDetail> EtdModelDetails { get; set; }

    public virtual DbSet<EtdMstModel> EtdMstModels { get; set; }

    public virtual DbSet<EtdMstPart> EtdMstParts { get; set; }

    public virtual DbSet<EtdMstPartType> EtdMstPartTypes { get; set; }

    public virtual DbSet<EtdMstProgram> EtdMstPrograms { get; set; }

    public virtual DbSet<EtdMstRank> EtdMstRanks { get; set; }

    public virtual DbSet<EtdProgramDetail> EtdProgramDetails { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.226.145;Database=dbIoTFac2;TrustServerCertificate=True;uid=sa;password=decjapan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EtdGroupRank>(entity =>
        {
            entity.HasKey(e => e.GId);

            entity.ToTable("etd_group_rank");

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

        modelBuilder.Entity<EtdModelDetail>(entity =>
        {
            entity.HasKey(e => new { e.MId, e.PId, e.PtId });

            entity.ToTable("etd_model_detail");

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

        modelBuilder.Entity<EtdMstModel>(entity =>
        {
            entity.HasKey(e => e.MId);

            entity.ToTable("etd_mst_model");

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

        modelBuilder.Entity<EtdMstPart>(entity =>
        {
            entity.HasKey(e => e.PId);

            entity.ToTable("etd_mst_part");

            entity.Property(e => e.PId)
                .ValueGeneratedNever()
                .HasColumnName("p_id");
            entity.Property(e => e.PName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("p_name");
        });

        modelBuilder.Entity<EtdMstPartType>(entity =>
        {
            entity.HasKey(e => e.PtId);

            entity.ToTable("etd_mst_part_type");

            entity.Property(e => e.PtId)
                .ValueGeneratedNever()
                .HasColumnName("pt_id");
            entity.Property(e => e.PtName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pt_name");
        });

        modelBuilder.Entity<EtdMstProgram>(entity =>
        {
            entity.HasKey(e => e.ProId);

            entity.ToTable("etd_mst_program");

            entity.Property(e => e.ProId)
                .ValueGeneratedNever()
                .HasColumnName("pro_id");
            entity.Property(e => e.ProName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pro_name");
            entity.Property(e => e.Yc)
                .HasMaxLength(50)
                .HasColumnName("yc");
        });

        modelBuilder.Entity<EtdMstRank>(entity =>
        {
            entity.HasKey(e => e.RId);

            entity.ToTable("etd_mst_rank");

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

        modelBuilder.Entity<EtdProgramDetail>(entity =>
        {
            entity.HasKey(e => e.MId);

            entity.ToTable("etd_program_detail");

            entity.Property(e => e.MId)
                .HasMaxLength(20)
                .HasColumnName("m_id");
            entity.Property(e => e.ProId).HasColumnName("pro_id");
        });

        //modelBuilder.Entity<EtdGroupRank>(entity =>
        //{
        //    entity.HasKey(e => e.GId);

        //    entity.ToTable("MC_etd_group_rank");

        //    entity.Property(e => e.GId)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("g_id");
        //    entity.Property(e => e.RId)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("r_id");
        //    entity.Property(e => e.RName)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("r_name");
        //});

        //modelBuilder.Entity<EtdModelDetail>(entity =>
        //{
        //    entity.HasKey(e => new { e.MId, e.PId, e.PtId });

        //    entity.ToTable("MC_etd_model_detail");

        //    entity.Property(e => e.MId)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("m_id");
        //    entity.Property(e => e.PId)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("p_id");
        //    entity.Property(e => e.PtId)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("pt_id");
        //    entity.Property(e => e.PCycletime).HasColumnName("p_cycletime");
        //    entity.Property(e => e.PDate)
        //        .HasColumnType("smalldatetime")
        //        .HasColumnName("p_date");
        //    entity.Property(e => e.PMaxDimension).HasColumnName("p_max_dimension");
        //    entity.Property(e => e.PMidDimension).HasColumnName("p_mid_dimension");
        //    entity.Property(e => e.PMinDimension).HasColumnName("p_min_dimension");
        //    entity.Property(e => e.PStatus).HasColumnName("p_status");
        //    entity.Property(e => e.PUser)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("p_user");
        //    entity.Property(e => e.RId)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("r_id");
        //});

        //modelBuilder.Entity<EtdMstModel>(entity =>
        //{
        //    entity.HasKey(e => e.MId);

        //    entity.ToTable("MC_etd_mst_model");

        //    entity.Property(e => e.MId)
        //        .HasMaxLength(20)
        //        .HasColumnName("m_id");
        //    entity.Property(e => e.MDate)
        //        .HasColumnType("smalldatetime")
        //        .HasColumnName("m_date");
        //    entity.Property(e => e.MName)
        //        .HasMaxLength(50)
        //        .HasColumnName("m_name");
        //    entity.Property(e => e.MUser)
        //        .HasMaxLength(50)
        //        .HasColumnName("m_user");
        //});

        //modelBuilder.Entity<EtdMstPart>(entity =>
        //{
        //    entity.HasKey(e => e.PId);

        //    entity.ToTable("MC_etd_mst_part");

        //    entity.Property(e => e.PId)
        //        .ValueGeneratedNever()
        //        .HasColumnName("p_id");
        //    entity.Property(e => e.PName)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("p_name");
        //});

        //modelBuilder.Entity<EtdMstPartType>(entity =>
        //{
        //    entity.HasKey(e => e.PtId);

        //    entity.ToTable("MC_etd_mst_part_type");

        //    entity.Property(e => e.PtId)
        //        .ValueGeneratedNever()
        //        .HasColumnName("pt_id");
        //    entity.Property(e => e.PtName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("pt_name");
        //});

        //modelBuilder.Entity<EtdMstProgram>(entity =>
        //{
        //    entity.HasKey(e => e.ProId);

        //    entity.ToTable("MC_etd_mst_program");

        //    entity.Property(e => e.ProId)
        //        .ValueGeneratedNever()
        //        .HasColumnName("pro_id");
        //    entity.Property(e => e.ProName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("pro_name");
        //    entity.Property(e => e.Yc)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("yc");
        //});

        //modelBuilder.Entity<EtdMstRank>(entity =>
        //{
        //    entity.HasKey(e => e.RId);

        //    entity.ToTable("MC_etd_mst_rank");

        //    entity.Property(e => e.RId)
        //        .ValueGeneratedNever()
        //        .HasColumnName("r_id");
        //    entity.Property(e => e.RColor)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("r_color");
        //    entity.Property(e => e.RName)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("r_name");
        //});

        //modelBuilder.Entity<EtdProgramDetail>(entity =>
        //{
        //    entity.HasKey(e => e.MId);

        //    entity.ToTable("MC_etd_program_detail");

        //    entity.Property(e => e.MId)
        //        .HasMaxLength(20)
        //        .HasColumnName("m_id");
        //    entity.Property(e => e.ProId).HasColumnName("pro_id");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public dynamic getFilter(MOther obj)
    {
        string fac = obj.fac;
        string line = obj.line;
        string proId = (obj.proId != "" && obj.proId != null) ? obj.proId.ToString() : "";
        if (line == "Machine")
        {
            var listProgram = EtdMstPrograms.ToList();
            var result = (from mstProd in listProgram
                          join prodDetail in EtdProgramDetails
                          on mstProd.ProId equals prodDetail.ProId
                          join mstModel in EtdMstModels
                          on prodDetail.MId equals mstModel.MId
                          select new { mstProd.ProId, mstProd.ProName, prodDetail.MId, mstModel.MName }).ToList();
            if (proId == "")
            {
                proId = result.ToList()[0].ProId.ToString();
            }
            var listModel = result.Where(x => x.ProId.ToString() == proId).ToList().DistinctBy(x => x.MName).OrderBy(x => x.MName);
            var modelSelected = listModel.ToList().Count > 0 ? listModel.ToList()[0].MId : "";
            return new { id = proId, program = listProgram, model = listModel, modelSelected = modelSelected };
        }
        else
        {
            var listProgram = EtdMstPrograms.ToList();
            var result = (from mstProd in listProgram
                          join prodDetail in EtdProgramDetails
                          on mstProd.ProId equals prodDetail.ProId
                          join mstModel in EtdMstModels
                          on prodDetail.MId equals mstModel.MId
                          select new { mstProd.ProId, mstProd.ProName, prodDetail.MId, mstModel.MName }).ToList();
            if (proId == "")
            {
                proId = result.ToList()[0].ProId.ToString();
            }
            var listModel = result.Where(x => x.ProId.ToString() == proId).ToList().DistinctBy(x => x.MName).OrderBy(x => x.MName);
            var modelSelected = listModel.ToList().Count > 0 ? listModel.ToList()[0].MId : "";
            return new { id = proId, program = listProgram.DistinctBy(x => x.ProId), model = listModel, modelSelected = modelSelected };
        }
    }
}
