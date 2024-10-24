using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using FestCover.Application.Common.Contracts;
using FestCover.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Infrastructure.Common.Persistence.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        private readonly IUserService _tenant;
        public AuditInterceptor(IUserService tenant)
        {
            _tenant = tenant;
        }
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            SetAudit(eventData.Context);
            return base.SavingChanges(eventData, result);
        }
        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            SetAudit(eventData.Context);
            SetUser(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void SetUser(DbContext? dbContext)
        {
            if (dbContext is null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(_tenant.GetCurrentUserId()))
            {
                var currentUser = UserId.Create(Guid.Parse(_tenant.GetCurrentUserId()));
                var entries = dbContext.ChangeTracker.Entries();
                foreach (var entry in entries)
                {
                    if (entry.Entity is IBaseUser)
                    {

                        switch (entry.State)
                        {
                            case EntityState.Added:
                                ((IBaseUser)entry.Entity).SetUserId(currentUser);
                                break;
                        }
                    }
                    if (entry.Entity is ISoftDelete)
                    {

                        switch (entry.State)
                        {
                            case EntityState.Deleted:
                                entry.State = EntityState.Modified;
                                ((ISoftDelete)entry.Entity).SetIsDeleted(true);
                                break;
                        }
                    }
                }
            }

        }
        public void SetAudit(DbContext? dbContext)
        {
            if (dbContext is null)
            {
                return;
            }
            var entries = dbContext.ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IBaseEntity)
                {

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            ((IBaseEntity)entry.Entity).SetCreatedDate(DateTime.Now);
                            ((IBaseEntity)entry.Entity).SetLastModifiedDate(DateTime.Now);
                            break;
                        case EntityState.Modified:
                            ((IBaseEntity)entry.Entity).SetLastModifiedDate(DateTime.Now);
                            break;
                    }
                }
            }
        }

    }
}

