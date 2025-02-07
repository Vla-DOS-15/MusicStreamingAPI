namespace MusicStreaming.API.Entities
{
    public class Lyrics
    {
        public int LyricsId { get; set; }
        public int TrackId { get; set; }
        public string LineText { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public Track Track { get; set; }
    }

}
