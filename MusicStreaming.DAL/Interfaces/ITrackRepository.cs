using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStreaming.API.Entities;

namespace MusicStreaming.DAL.Interfaces
{
    public interface ITrackRepository : IGenericRepository<Track>
    {
        Task<IEnumerable<Track>> GetTracksByArtistId(int artistId);
        Task<IEnumerable<Track>> GetTracksByGenreId(int genreId);
        Task<IEnumerable<Track>> GetMostPlayedTracks(int count);
    }
}
