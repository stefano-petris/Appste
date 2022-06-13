using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyCourse.Models.Entities;

namespace MyCourse.Models.Services.Infrastructure
{
    public partial class MyCourseDbContext : DbContext
    {
        public MyCourseDbContext()
        {
        }

        public MyCourseDbContext(DbContextOptions<MyCourseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source =Data/MyCourse.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Author).HasColumnType("TEXT(100)");

                entity.Property(e => e.CurrentPriceAmount)
                    .HasColumnType("NUMERIC")
                    .HasColumnName("CurrentPrice_Amount")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CurrentPriceCurrency)
                    .HasColumnType("TEXT(3)")
                    .HasColumnName("CurrentPrice_Currency")
                    .HasDefaultValueSql("'EUR'");

                entity.Property(e => e.Description).HasColumnType("TEXT(10000)");

                entity.Property(e => e.Email).HasColumnType("TEXT(100)");

                entity.Property(e => e.FullPriceCurrency)
                    .HasColumnType("TEXT(3)")
                    .HasColumnName("FullPrice_Currency")
                    .HasDefaultValueSql("'EUR'");

                entity.Property(e => e.FullPticeAmount)
                    .HasColumnType("NUMERIC")
                    .HasColumnName("FullPtice_Amount")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ImagePath).HasColumnType("TEXT(100)");

                entity.Property(e => e.Title).HasColumnType("TEXT (100)");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("TEXT(10000)");

                entity.Property(e => e.Duration)
                    .HasColumnType("TEXT(8)")
                    .HasDefaultValueSql("'00.00.00'");

                entity.Property(e => e.Title).HasColumnType("TEXT (100)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.CourseId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
