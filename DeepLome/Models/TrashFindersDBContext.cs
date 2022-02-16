using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DeepLome.Models
{
    public partial class TrashFindersDBContext : DbContext
    {
        public TrashFindersDBContext()
        {
        }

        public TrashFindersDBContext(DbContextOptions<TrashFindersDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<Trash> Trashes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersAtEvent> UsersAtEvents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=D:\\Programms\\SQLiteStudio\\TrashFindersDB.db");
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

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SizeName).HasColumnType("NVARCHAR(255)");
            });

            modelBuilder.Entity<Trash>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.UserId).HasColumnType("INT");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Trashes)
                    .HasForeignKey(d => d.SizeId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trashes)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.LastName).HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.Phone).HasColumnType("NVARCHAR(127)");
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
