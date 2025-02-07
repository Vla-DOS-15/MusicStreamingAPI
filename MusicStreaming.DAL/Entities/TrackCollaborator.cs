namespace MusicStreaming.API.Entities
{
    public class TrackCollaborator
    {
        public int TrackId { get; set; }
        public Track Track { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public string Role { get; set; } // Наприклад: "Songwriter", "Producer"
    }

}
