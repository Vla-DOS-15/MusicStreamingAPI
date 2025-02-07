namespace MusicStreaming.API.Entities
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public int UserId { get; set; } // Зв’язок із користувачем
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Country { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User User { get; set; } // Посилання на користувача
        public ICollection<Album> Albums { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public ICollection<TrackCollaborator> Collaborations { get; set; }
    }

}
