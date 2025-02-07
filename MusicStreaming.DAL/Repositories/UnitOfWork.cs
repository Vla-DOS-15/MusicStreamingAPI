using MusicStreaming.API.Entities;
using MusicStreaming.DAL.Interfaces;
using MusicStreaming.DAL.DataContext;

namespace MusicStreaming.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<User> Users { get; }
        public IGenericRepository<Artist> Artists { get; }
        public IGenericRepository<Album> Albums { get; }
        public IGenericRepository<Track> Tracks { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new GenericRepository<User>(_context);
            Artists = new GenericRepository<Artist>(_context);
            Albums = new GenericRepository<Album>(_context);
            Tracks = new GenericRepository<Track>(_context);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
