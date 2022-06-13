using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusicPlayerWPF.DB
{
    public partial class MusicPlayerContext : DbContext
    {
        public MusicPlayerContext()
        {
        }

        public MusicPlayerContext(DbContextOptions<MusicPlayerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MusicGenre> MusicGenres { get; set; } = null!;
        public virtual DbSet<Playlist> Playlists { get; set; } = null!;
        public virtual DbSet<Track> Tracks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; DataBase=MusicPlayer; trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MusicGenre>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                    .HasName("PK__MusicGen__0385055E25CB9788");

                entity.ToTable("MusicGenre");

                entity.Property(e => e.GenreId)
                    .ValueGeneratedNever()
                    .HasColumnName("GenreID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("Playlist");

                entity.Property(e => e.PlaylistId)
                    .ValueGeneratedNever()
                    .HasColumnName("PlaylistID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("Track");

                entity.Property(e => e.TrackId)
                    .ValueGeneratedNever()
                    .HasColumnName("TrackID");

                entity.Property(e => e.GenreId)
                    .HasColumnName("GenreID")
                    .HasDefaultValueSql("('Uncategorized')");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlaylistId).HasColumnName("PlaylistID");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_Track_MusicGenre");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.PlaylistId)
                    .HasConstraintName("FK_Track_Playlist");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
