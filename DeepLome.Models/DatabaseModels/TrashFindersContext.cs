using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DeepLome.WebApi.Models
{
    public partial class TrashFindersContext : DbContext
    {
        public TrashFindersContext()
        {
        }

        public TrashFindersContext(DbContextOptions<TrashFindersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventPhoto> EventPhotos { get; set; } = null!;
        public virtual DbSet<Photo> Photos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersAtEvent> UsersAtEvents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=C:\\Users\\Kirul\\Desktop\\DeepLome\\DeepLome\\DeepLome\\TrashFinders.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDateTime).HasColumnType("DATETIME");

                entity.Property(e => e.EventDescription).HasColumnType("NVARCHAR(4095)");

                entity.Property(e => e.EventName).HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.StartDateTime).HasColumnType("DATETIME");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CreatorId);
            });

            modelBuilder.Entity<EventPhoto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventPhotos)
                    .HasForeignKey(d => d.EventId);

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.EventPhotos)
                    .HasForeignKey(d => d.PhotoId);
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Photo1).HasColumnName("Photo");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.LastName).HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.Phone).HasColumnType("NVARCHAR(127)");

                entity.Property(e => e.UserName).HasColumnType("NVARCHAR(1023)");
            });

            modelBuilder.Entity<UsersAtEvent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UsersAtEvent");

                entity.HasOne(d => d.Event)
                    .WithMany()
                    .HasForeignKey(d => d.EventId);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
