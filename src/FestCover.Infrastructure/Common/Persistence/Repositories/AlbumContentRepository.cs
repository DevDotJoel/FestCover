using FestCover.Application.Common.Persistence;
using FestCover.Domain.AlbumContents;
using FestCover.Domain.AlbumContents.ValueObjects;
using FestCover.Domain.Albums.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FestCover.Infrastructure.Common.Persistence.Repositories
{
    public class AlbumContentRepository : IAlbumContentRepository
    {
        private readonly FestCoverDbContext _context;
        public AlbumContentRepository(FestCoverDbContext context)
        {
            _context = context;

        }
        public async Task AddAsync(AlbumContent entity, CancellationToken cancellationToken)
        {
            await _context.AlbumContents.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(AlbumContentId id)
        {
            return await _context.AlbumContents.AnyAsync(albumContent => albumContent.Id == id);
        }

        public async Task<List<AlbumContent>> GetAlbumContentsByAlbumId(AlbumId albumId, CancellationToken cancellationToken)
        {
            return await _context.AlbumContents.Where(ac=>ac.AlbumId==albumId).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<List<AlbumContent>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.AlbumContents.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<List<AlbumContent>> GetAllWithPaginationAsync(int page, int size, CancellationToken cancellationToken)
        {
            return await _context.AlbumContents.AsNoTracking().Skip(page).Take(size).ToListAsync(cancellationToken);
        }

        public async Task<AlbumContent> GetByIdAsync(AlbumContentId id, CancellationToken cancellationToken)
        {
            return await _context.AlbumContents.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<AlbumContent>> GetByIdsAsync(List<AlbumContentId> ids, CancellationToken cancellationToken)
        {
            return await _context.AlbumContents.Where(p => ids.Contains(p.Id)).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<List<AlbumContent>> GetPendingAlbumContents(CancellationToken cancellationToken)
        {
            return await _context.AlbumContents.Where(ac => ac.Pending==true).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task RemoveAsync(AlbumContent entity, CancellationToken cancellationToken)
        {
            _context.AlbumContents.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveRangeAsync(List<AlbumContent> entities, CancellationToken cancellationToken)
        {
            _context.AlbumContents.RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(AlbumContent entity, CancellationToken cancellationToken)
        {
            _context.AlbumContents.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
