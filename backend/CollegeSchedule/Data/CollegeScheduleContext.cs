using System;
using System.Collections.Generic;
using CollegeSchedule.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeSchedule.Data;

public partial class CollegeScheduleContext : DbContext
{
    public CollegeScheduleContext()
    {
    }

    public CollegeScheduleContext(DbContextOptions<CollegeScheduleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<building> buildings { get; set; }

    public virtual DbSet<classroom> classrooms { get; set; }

    public virtual DbSet<lesson_time> lesson_times { get; set; }

    public virtual DbSet<schedule> schedules { get; set; }

    public virtual DbSet<specialty> specialties { get; set; }

    public virtual DbSet<student_group> student_groups { get; set; }

    public virtual DbSet<subject> subjects { get; set; }

    public virtual DbSet<teacher> teachers { get; set; }

    public virtual DbSet<weekday> weekdays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("lesson_group_part", new[] { "FULL", "SUB1", "SUB2" });

        modelBuilder.Entity<building>(entity =>
        {
            entity.HasKey(e => e.building_id).HasName("building_pkey");

            entity.ToTable("building");

            entity.HasIndex(e => e.address, "building_address_key").IsUnique();
        });

        modelBuilder.Entity<classroom>(entity =>
        {
            entity.HasKey(e => e.classroom_id).HasName("classroom_pkey");

            entity.ToTable("classroom");

            entity.HasIndex(e => new { e.building_id, e.room_number }, "uq_classroom").IsUnique();

            entity.HasOne(d => d.building).WithMany(p => p.classrooms)
                .HasForeignKey(d => d.building_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_classroom_building");
        });

        modelBuilder.Entity<lesson_time>(entity =>
        {
            entity.HasKey(e => e.lesson_time_id).HasName("lesson_time_pkey");

            entity.ToTable("lesson_time");
        });

        modelBuilder.Entity<schedule>(entity =>
        {
            entity.HasKey(e => e.schedule_id).HasName("schedule_pkey");

            entity.ToTable("schedule");

            entity.HasIndex(e => new { e.lesson_date, e.lesson_time_id, e.classroom_id }, "uq_schedule_classroom_time").IsUnique();

            entity.HasOne(d => d.classroom).WithMany(p => p.schedules)
                .HasForeignKey(d => d.classroom_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_schedule_classroom");

            entity.HasOne(d => d.group).WithMany(p => p.schedules)
                .HasForeignKey(d => d.group_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_schedule_group");

            entity.HasOne(d => d.lesson_time).WithMany(p => p.schedules)
                .HasForeignKey(d => d.lesson_time_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_schedule_lesson_time");

            entity.HasOne(d => d.subject).WithMany(p => p.schedules)
                .HasForeignKey(d => d.subject_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_schedule_subject");

            entity.HasOne(d => d.teacher).WithMany(p => p.schedules)
                .HasForeignKey(d => d.teacher_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_schedule_teacher");

            entity.HasOne(d => d.weekday).WithMany(p => p.schedules)
                .HasForeignKey(d => d.weekday_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_schedule_weekday");
        });

        modelBuilder.Entity<specialty>(entity =>
        {
            entity.HasKey(e => e.id).HasName("specialties_pkey");
        });

        modelBuilder.Entity<student_group>(entity =>
        {
            entity.HasKey(e => e.group_id).HasName("student_group_pkey");

            entity.ToTable("student_group");

            entity.HasIndex(e => e.group_name, "student_group_group_name_key").IsUnique();

            entity.HasOne(d => d.specialty).WithMany(p => p.student_groups)
                .HasForeignKey(d => d.specialty_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_specialty");
        });

        modelBuilder.Entity<subject>(entity =>
        {
            entity.HasKey(e => e.subject_id).HasName("subject_pkey");

            entity.ToTable("subject");

            entity.HasIndex(e => e.name, "subject_name_key").IsUnique();
        });

        modelBuilder.Entity<teacher>(entity =>
        {
            entity.HasKey(e => e.teacher_id).HasName("teacher_pkey");

            entity.ToTable("teacher");
        });

        modelBuilder.Entity<weekday>(entity =>
        {
            entity.HasKey(e => e.weekday_id).HasName("weekday_pkey");

            entity.ToTable("weekday");

            entity.HasIndex(e => e.name, "weekday_name_key").IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
