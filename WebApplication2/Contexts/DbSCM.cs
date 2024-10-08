﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using imsmasterApi.Models;

namespace imsmasterApi.Contexts;

public partial class DBSCM : DbContext
{
    public DBSCM()
    {
    }

    public DBSCM(DbContextOptions<DBSCM> options)
        : base(options)
    {
    }

    public virtual DbSet<PnCompressor> PnCompressors { get; set; }

    public virtual DbSet<WmsMdw27ModelMaster> WmsMdw27ModelMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.226.86;Database=dbSCM;TrustServerCertificate=True;uid=sa;password=decjapan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_CI_AS");

        modelBuilder.Entity<PnCompressor>(entity =>
        {
            entity.HasKey(e => new { e.ModelCode, e.Model, e.Line });

            entity.ToTable("PN_Compressor");

            entity.Property(e => e.ModelCode).HasMaxLength(20);
            entity.Property(e => e.Model).HasMaxLength(250);
            entity.Property(e => e.CreateBy).HasMaxLength(20);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ModelGroup).HasMaxLength(50);
            entity.Property(e => e.ModelType)
                .HasMaxLength(10)
                .HasDefaultValueSql("(N'1YC')");
            entity.Property(e => e.Rmk1)
                .HasMaxLength(250)
                .HasComment("Model customer")
                .HasColumnName("rmk1");
            entity.Property(e => e.Rmk10)
                .HasMaxLength(250)
                .HasComment("data for check original line (backflush)")
                .HasColumnName("rmk10");
            entity.Property(e => e.Rmk2)
                .HasMaxLength(250)
                .HasComment("Pallate")
                .HasColumnName("rmk2");
            entity.Property(e => e.Rmk3)
                .HasMaxLength(250)
                .HasComment("Magnet")
                .HasColumnName("rmk3");
            entity.Property(e => e.Rmk4)
                .HasMaxLength(250)
                .HasColumnName("rmk4");
            entity.Property(e => e.Rmk5)
                .HasMaxLength(250)
                .HasComment("bit for check terminal cover")
                .HasColumnName("rmk5");
            entity.Property(e => e.Rmk6)
                .HasMaxLength(250)
                .HasColumnName("rmk6");
            entity.Property(e => e.Rmk7)
                .HasMaxLength(250)
                .HasColumnName("rmk7");
            entity.Property(e => e.Rmk8)
                .HasMaxLength(250)
                .HasColumnName("rmk8");
            entity.Property(e => e.Rmk9)
                .HasMaxLength(250)
                .HasColumnName("rmk9");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasDefaultValueSql("(N'active')");
            entity.Property(e => e.UpdateBy).HasMaxLength(20);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<WmsMdw27ModelMaster>(entity =>
        {
            entity.HasKey(e => new { e.Model, e.Modelgroup, e.Pltype, e.Strloc, e.Rev, e.Lrev, e.Strdate, e.Enddate, e.Remark, e.Sebango, e.Diameter }).HasName("PK_WMS_MDW27_MODEL_MASTER_1");

            entity.ToTable("WMS_MDW27_MODEL_MASTER");

            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("MODEL");
            entity.Property(e => e.Modelgroup)
                .HasMaxLength(3)
                .HasColumnName("MODELGROUP");
            entity.Property(e => e.Pltype)
                .HasMaxLength(50)
                .HasColumnName("PLTYPE");
            entity.Property(e => e.Strloc)
                .HasMaxLength(50)
                .HasColumnName("STRLOC");
            entity.Property(e => e.Rev).HasColumnName("REV");
            entity.Property(e => e.Lrev).HasColumnName("LREV");
            entity.Property(e => e.Strdate)
                .HasMaxLength(8)
                .HasColumnName("STRDATE");
            entity.Property(e => e.Enddate)
                .HasMaxLength(8)
                .HasColumnName("ENDDATE");
            entity.Property(e => e.Remark)
                .HasMaxLength(50)
                .HasColumnName("REMARK");
            entity.Property(e => e.Sebango)
                .HasMaxLength(50)
                .HasColumnName("SEBANGO");
            entity.Property(e => e.Diameter)
                .HasMaxLength(50)
                .HasColumnName("DIAMETER");
            entity.Property(e => e.Active)
                .HasMaxLength(20)
                .HasDefaultValueSql("(N'INACTIVE')")
                .HasColumnName("ACTIVE");
            entity.Property(e => e.Area)
                .HasMaxLength(20)
                .HasColumnName("AREA");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'every 8.30 AM')")
                .HasColumnName("CREATE_BY");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATE_DATE");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
