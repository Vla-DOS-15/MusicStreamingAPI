namespace MusicStreaming.API.Entities
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }      // Основний виконавець
        public int? AlbumId { get; set; }
        public TimeSpan Duration { get; set; }
        public string FileUrl { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public int PlayCount { get; set; } = 0;

        public Artist Artist { get; set; }
        public Album Album { get; set; }

        public ICollection<TrackGenre> TrackGenres { get; set; }
        public ICollection<Lyrics> Lyrics { get; set; }
        public ICollection<TrackReaction> TrackReactions { get; set; }
        public ICollection<PlaylistTrack> PlaylistTracks { get; set; }
        public ICollection<ListeningHistory> ListeningHistory { get; set; }
        public ICollection<TrackCollaborator> Collaborators { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }

}
