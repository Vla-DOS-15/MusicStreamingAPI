namespace MusicStreaming.API.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int TrackId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User User { get; set; }
        public Track Track { get; set; }
    }

}
