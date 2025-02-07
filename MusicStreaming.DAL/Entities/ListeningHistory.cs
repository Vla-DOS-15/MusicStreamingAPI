namespace MusicStreaming.API.Entities
{
    public class ListeningHistory
    {
        public int ListeningHistoryId { get; set; }
        public int UserId { get; set; }
        public int TrackId { get; set; }
        public DateTime PlayedAt { get; set; } = DateTime.Now;

        public User User { get; set; }
        public Track Track { get; set; }
    }

}
