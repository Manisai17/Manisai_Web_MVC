using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Manisai_WEB_MVC.Models;

public partial class LmsContext : DbContext
{
    public LmsContext()
    {
    }

    public LmsContext(DbContextOptions<LmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coursemaster> Coursemasters { get; set; }

    public virtual DbSet<Studentattemptdetail> Studentattemptdetails { get; set; }

    public virtual DbSet<Studentattemptsummary> Studentattemptsummaries { get; set; }

    public virtual DbSet<Studentmaster> Studentmasters { get; set; }

    public virtual DbSet<Testmaster> Testmasters { get; set; }

    public virtual DbSet<Testquestion> Testquestions { get; set; }

    public virtual DbSet<Usermaster> Usermasters { get; set; }

  //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("Server=localhost;Database=lms;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coursemaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__coursema__3213E83FE07B0B72");

            entity.ToTable("coursemaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coursename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("coursename");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Modules)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("modules");
        });

        modelBuilder.Entity<Studentattemptdetail>(entity =>
        {
            entity.ToTable("studentattemptdetails");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fkstudid).HasColumnName("fkstudid");
            entity.Property(e => e.Fktestquestionid).HasColumnName("fktestquestionid");
            entity.Property(e => e.Iscorrect).HasColumnName("iscorrect");
            entity.Property(e => e.Selectedans).HasColumnName("selectedans");

            entity.HasOne(d => d.Fkstud).WithMany(p => p.Studentattemptdetails)
                .HasForeignKey(d => d.Fkstudid)
                .HasConstraintName("FK_studentattemptdetails_studentmaster");

            entity.HasOne(d => d.Fktestquestion).WithMany(p => p.Studentattemptdetails)
                .HasForeignKey(d => d.Fktestquestionid)
                .HasConstraintName("FK_studentattemptdetails_testquestions");
        });

        modelBuilder.Entity<Studentattemptsummary>(entity =>
        {
            entity.ToTable("studentattemptsummary");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attemptdate).HasColumnName("attemptdate");
            entity.Property(e => e.Fkstudid).HasColumnName("fkstudid");
            entity.Property(e => e.Fktestid).HasColumnName("fktestid");
            entity.Property(e => e.Result).HasColumnName("result");

            entity.HasOne(d => d.Fkstud).WithMany(p => p.Studentattemptsummaries)
                .HasForeignKey(d => d.Fkstudid)
                .HasConstraintName("FK_studentattemptsummary_studentmaster");

            entity.HasOne(d => d.Fktest).WithMany(p => p.Studentattemptsummaries)
                .HasForeignKey(d => d.Fktestid)
                .HasConstraintName("FK_studentattemptsummary_testmaster");
        });

        modelBuilder.Entity<Studentmaster>(entity =>
        {
            entity.ToTable("studentmaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Emailid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emailid");
            entity.Property(e => e.Fkcourseid).HasColumnName("fkcourseid");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Photo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("photo");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Studname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("studname");

            entity.HasOne(d => d.Fkcourse).WithMany(p => p.Studentmasters)
                .HasForeignKey(d => d.Fkcourseid)
                .HasConstraintName("FK_studentmaster_coursemaster");
        });

        modelBuilder.Entity<Testmaster>(entity =>
        {
            entity.ToTable("testmaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Fkcourseid).HasColumnName("fkcourseid");
            entity.Property(e => e.Testname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("testname");
            entity.Property(e => e.Totquestions).HasColumnName("totquestions");

            entity.HasOne(d => d.Fkcourse).WithMany(p => p.Testmasters)
                .HasForeignKey(d => d.Fkcourseid)
                .HasConstraintName("FK_testmaster_coursemaster");
        });

        modelBuilder.Entity<Testquestion>(entity =>
        {
            entity.ToTable("testquestions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("answer1");
            entity.Property(e => e.Answer2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("answer2");
            entity.Property(e => e.Answer3)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("answer3");
            entity.Property(e => e.Answer4)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("answer4");
            entity.Property(e => e.Correctans).HasColumnName("correctans");
            entity.Property(e => e.Explanation)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("explanation");
            entity.Property(e => e.Fktestid).HasColumnName("fktestid");
            entity.Property(e => e.Question)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("question");

            entity.HasOne(d => d.Fktest).WithMany(p => p.Testquestions)
                .HasForeignKey(d => d.Fktestid)
                .HasConstraintName("FK_testquestions_testmaster");
        });

        modelBuilder.Entity<Usermaster>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__usermast__1788CC4CA790C1C4");

            entity.ToTable("usermasters");

            entity.HasIndex(e => e.Username, "UQ__usermast__536C85E49836DA4F").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
