namespace MusicStreaming.API.Entities
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }

        public Artist Artist { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }

}
