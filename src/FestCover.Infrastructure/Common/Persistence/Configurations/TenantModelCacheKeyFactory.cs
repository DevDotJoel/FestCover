using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace FestCover.Infrastructure.Common.Persistence.Configurations
{
    public class TenantModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context, bool designTime) =>
       context switch
       {
           AppDbContext appContext => (context.GetType(), appContext.TenantId, designTime),
           _ => context.GetType()
       };

        public object Create(DbContext context)
           => Create(context, false);
    }
}
