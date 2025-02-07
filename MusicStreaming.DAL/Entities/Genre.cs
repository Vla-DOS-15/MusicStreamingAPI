namespace MusicStreaming.API.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<TrackGenre> TrackGenres { get; set; }
    }

}
