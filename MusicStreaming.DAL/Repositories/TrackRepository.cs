using Microsoft.EntityFrameworkCore;
using MusicStreaming.API.Entities;
using MusicStreaming.DAL.DataContext;
using MusicStreaming.DAL.Interfaces;

namespace MusicStreaming.DAL.Repositories
{
    public class TrackRepository : GenericRepository<Track>, ITrackRepository
    {
        private readonly AppDbContext _context;

        public TrackRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Track>> GetTracksByArtistId(int artistId)
        {
            return await _context.Tracks
                .Where(t => t.ArtistId == artistId)
                .Include(t => t.Artist)
                .ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetTracksByGenreId(int genreId)
        {
            return await _context.Tracks
                .Where(t => t.TrackGenres.Any(g => g.GenreId == genreId))
                .Include(t => t.TrackGenres)
                .ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetMostPlayedTracks(int count)
        {
            return await _context.Tracks
                .OrderByDescending(t => t.PlayCount)
                .Take(count)
                .ToListAsync();
        }
    }
}
