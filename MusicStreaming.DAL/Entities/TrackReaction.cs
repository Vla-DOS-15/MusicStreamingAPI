namespace MusicStreaming.API.Entities
{
    public class TrackReaction
    {
        public int TrackReactionId { get; set; }
        public int UserId { get; set; }
        public int TrackId { get; set; }
        public bool IsLiked { get; set; }
        public DateTime ReactionDate { get; set; } = DateTime.Now;

        public User User { get; set; }
        public Track Track { get; set; }
    }

}
