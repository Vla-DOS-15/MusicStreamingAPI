using Microsoft.EntityFrameworkCore;
using MusicStreaming.API.Entities;

namespace MusicStreaming.DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // ✅ Таблиці користувачів і виконавців
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }

        // ✅ Таблиці для музики
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Lyrics> Lyrics { get; set; }

        // ✅ Зв’язок багато-до-багатьох
        public DbSet<TrackGenre> TrackGenres { get; set; }
        public DbSet<TrackCollaborator> TrackCollaborators { get; set; }

        // ✅ Плейлисти та історія прослуховувань
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistTrack> PlaylistTracks { get; set; }
        public DbSet<ListeningHistory> ListeningHistory { get; set; }

        // ✅ Реакції, коментарі, підписки
        public DbSet<TrackReaction> TrackReactions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Зв'язок один-до-одного: User ↔ Artist
            modelBuilder.Entity<Artist>()
                .HasOne(a => a.User)
                .WithOne(u => u.ArtistProfile)
                .HasForeignKey<Artist>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ✅ Багато-до-багатьох: Track ↔ Genre
            modelBuilder.Entity<TrackGenre>()
                .HasKey(tg => new { tg.TrackId, tg.GenreId });

            modelBuilder.Entity<TrackGenre>()
                .HasOne(tg => tg.Track)
                .WithMany(t => t.TrackGenres)
                .HasForeignKey(tg => tg.TrackId);

            modelBuilder.Entity<TrackGenre>()
                .HasOne(tg => tg.Genre)
                .WithMany(g => g.TrackGenres)
                .HasForeignKey(tg => tg.GenreId);

            // ✅ Багато-до-багатьох: Track ↔ Collaborator (Artist)
            modelBuilder.Entity<TrackCollaborator>()
                .HasKey(tc => new { tc.TrackId, tc.ArtistId });

            modelBuilder.Entity<TrackCollaborator>()
                .HasOne(tc => tc.Track)
                .WithMany(t => t.Collaborators)
                .HasForeignKey(tc => tc.TrackId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrackCollaborator>()
                .HasOne(tc => tc.Artist)
                .WithMany(a => a.Collaborations)
                .HasForeignKey(tc => tc.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ Плейлист ↔ Трек (унікальність треку в плейлисті)
            modelBuilder.Entity<PlaylistTrack>()
                .HasIndex(pt => new { pt.PlaylistId, pt.TrackId })
                .IsUnique();

            modelBuilder.Entity<PlaylistTrack>()
                .HasOne(pt => pt.Playlist)
                .WithMany(p => p.PlaylistTracks)
                .HasForeignKey(pt => pt.PlaylistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlaylistTrack>()
                .HasOne(pt => pt.Track)
                .WithMany(t => t.PlaylistTracks)
                .HasForeignKey(pt => pt.TrackId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ Унікальність реакції (лайк/дизлайк) на трек для одного користувача
            modelBuilder.Entity<TrackReaction>()
                .HasIndex(tr => new { tr.UserId, tr.TrackId })
                .IsUnique();

            modelBuilder.Entity<TrackReaction>()
                .HasOne(tr => tr.User)
                .WithMany(u => u.TrackReactions)
                .HasForeignKey(tr => tr.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrackReaction>()
                .HasOne(tr => tr.Track)
                .WithMany(t => t.TrackReactions)
                .HasForeignKey(tr => tr.TrackId)
                .OnDelete(DeleteBehavior.Cascade);

            // ✅ Коментарі до треків
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Track)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TrackId)
                .OnDelete(DeleteBehavior.Cascade);

            // ✅ Історія прослуховувань
            modelBuilder.Entity<ListeningHistory>()
                .HasOne(lh => lh.User)
                .WithMany(u => u.ListeningHistory)
                .HasForeignKey(lh => lh.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ListeningHistory>()
                .HasOne(lh => lh.Track)
                .WithMany(t => t.ListeningHistory)
                .HasForeignKey(lh => lh.TrackId)
                .OnDelete(DeleteBehavior.Cascade);

            // ✅ Підписки користувачів
            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.User)
                .WithMany(u => u.Subscriptions)
                .HasForeignKey(s => s.UserId);
        }
    }
}
