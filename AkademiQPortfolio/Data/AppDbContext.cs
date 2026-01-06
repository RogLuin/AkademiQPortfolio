using System;
using System.Collections.Generic;
using AkademiQPortfolio.Entities;
using Microsoft.EntityFrameworkCore;

namespace AkademiQPortfolio.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }



    public virtual DbSet<About> Abouts { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Hobby> Hobbies { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Work> Works { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // intentionally left blank
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<About>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AboutId).ValueGeneratedOnAdd();
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ImageUrl).HasMaxLength(250);
            entity.Property(e => e.NameSurname).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.WebSite).HasMaxLength(50);
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.EducationDate).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.ExperianceId);

            entity.Property(e => e.CompanyName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IconUrl).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.WorkDate).HasMaxLength(50);
        });

        modelBuilder.Entity<Hobby>(entity =>
        {
            entity.Property(e => e.IconUrl).HasMaxLength(200);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.MessageText)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.SendDate).HasColumnType("datetime");
            entity.Property(e => e.SenderEmail).HasMaxLength(50);
            entity.Property(e => e.SenderName).HasMaxLength(50);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK_Skill");

            entity.Property(e => e.Skilltitle).HasMaxLength(50);
        });

        modelBuilder.Entity<Work>(entity =>
        {
            entity.Property(e => e.SubTitle).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
