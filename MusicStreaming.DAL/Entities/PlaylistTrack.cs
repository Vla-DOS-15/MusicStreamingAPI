namespace MusicStreaming.API.Entities
{
    public class PlaylistTrack
    {
        public int PlaylistTrackId { get; set; }
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.Now;

        public Playlist Playlist { get; set; }
        public Track Track { get; set; }
    }

}
