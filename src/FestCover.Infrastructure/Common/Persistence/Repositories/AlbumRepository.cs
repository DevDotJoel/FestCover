using Microsoft.EntityFrameworkCore;
using FestCover.Application.Common.Persistence;
using FestCover.Domain.Albums;
using FestCover.Domain.Albums.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FestCover.Domain.AlbumContents.ValueObjects;

namespace FestCover.Infrastructure.Common.Persistence.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly FestCoverDbContext _context;
        public AlbumRepository(FestCoverDbContext context)
        {
            _context = context;
            
        }
        public async Task AddAsync(Album entity, CancellationToken cancellationToken)
        {
            await _context.Albums.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(AlbumId id)
        {
            return await _context.Albums.AnyAsync(album => album.Id == id);
        }

        public async Task<Album> GetAlbumByKey(string key, CancellationToken cancellationToken)
        {
            return await _context.Albums.Where(album => album.Key == key).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Album>> GetAlbumsByAlbumContentIds(List<AlbumContentId> AlbumContentIds, CancellationToken cancellationToken)
        {
            return await _context.Albums.Where(p => p.AlbumContentIds.Any(aci=> AlbumContentIds.Contains(aci))).AsNoTracking().Distinct().ToListAsync(cancellationToken);
        }

        public  async Task<List<Album>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Albums.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<List<Album>> GetAllWithPaginationAsync(int page, int size, CancellationToken cancellationToken)
        {
            return await _context.Albums.AsNoTracking().Skip(page).Take(size).ToListAsync(cancellationToken);
        }

        public async Task<Album> GetByIdAsync(AlbumId id, CancellationToken cancellationToken)
        {
            return await _context.Albums.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Album>> GetByIdsAsync(List<AlbumId> ids, CancellationToken cancellationToken)
        {
            return await _context.Albums.Where(p => ids.Contains(p.Id)).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task RemoveAsync(Album entity, CancellationToken cancellationToken)
        {
            _context.Albums.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveRangeAsync(List<Album> entities, CancellationToken cancellationToken)
        {
            _context.Albums.RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Album entity, CancellationToken cancellationToken)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
