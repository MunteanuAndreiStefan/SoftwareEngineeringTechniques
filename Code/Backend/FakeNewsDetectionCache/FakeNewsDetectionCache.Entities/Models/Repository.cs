using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FakeNewsDetectionCache.Entities.Models
{
    public partial class Repository : DbContext
    {
        public Repository()
        {
        }

        public Repository(DbContextOptions<Repository> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<NewsArticle> NewsArticles { get; set; }
        public virtual DbSet<TwitterUser> TwitterUsers { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=FakeNewsDetectionCache;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<NewsArticle>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_FK_NewsArticeUser");

                entity.Property(e => e.Source).IsRequired();

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NewsArticles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NewsArticeUser");
            });

            modelBuilder.Entity<TwitterUser>(entity =>
            {
                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_FK_VoteApplicationUser");

                entity.HasIndex(e => e.NewsArticleId)
                    .HasName("IX_FK_VoteNewsArticle");

                entity.Property(e => e.ApplicationUserId).HasColumnName("ApplicationUser_Id");

                entity.Property(e => e.NewsArticleId).HasColumnName("NewsArticle_Id");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoteApplicationUser");

                entity.HasOne(d => d.NewsArticle)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.NewsArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoteNewsArticle");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
