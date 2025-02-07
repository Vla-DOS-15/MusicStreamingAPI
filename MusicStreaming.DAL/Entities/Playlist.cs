namespace MusicStreaming.API.Entities
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsPublic { get; set; } = true;

        public User User { get; set; }
        public ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }

}
