using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Webapi_Sys.Models
{
    public partial class ResumeDBContext : DbContext
    {
        public ResumeDBContext()
        {
        }

        public ResumeDBContext(DbContextOptions<ResumeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbResume> TbResumes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ResumeDB;UID =sa;PWD=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<TbResume>(entity =>
            {
                entity.HasKey(e => e.ResumeId);

                entity.ToTable("tb_Resume");

                entity.Property(e => e.ResumeId).HasColumnName("ResumeID");

                entity.Property(e => e.Education)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
