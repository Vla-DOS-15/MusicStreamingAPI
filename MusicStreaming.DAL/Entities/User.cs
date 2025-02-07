namespace MusicStreaming.API.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } = "User"; // User, Admin, Artist
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string ProfilePictureUrl { get; set; }

        public Artist ArtistProfile { get; set; } // Зв’язок з виконавцем
        public ICollection<Playlist> Playlists { get; set; }
        public ICollection<TrackReaction> TrackReactions { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ListeningHistory> ListeningHistory { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }

}
