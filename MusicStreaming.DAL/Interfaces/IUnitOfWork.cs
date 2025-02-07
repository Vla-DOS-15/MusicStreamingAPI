using MusicStreaming.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Artist> Artists { get; }
        IGenericRepository<Album> Albums { get; }
        IGenericRepository<Track> Tracks { get; }

        Task SaveAsync();
    }
}
