﻿using System;
using System.Threading.Tasks;
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

        public virtual DbSet<NewsArticle> NewsArticles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=BEE-WS-92\\SQLEXPRESS;Database=FakeNewsDetectionCache;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Username).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override ValueTask DisposeAsync()
    {
      return base.DisposeAsync();
    }
    public override void Dispose()
    {
      base.Dispose();
    }
  }
}