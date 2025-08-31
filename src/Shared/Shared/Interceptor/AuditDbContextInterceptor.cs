using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.Auth;
using Shared.DDD;

namespace Shared.Interceptor
{
    public class AuditDbContextInterceptor(IAuthorization authorization) : SaveChangesInterceptor
    {

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateAuditFields(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        private void UpdateAuditFields(DbContext? context)
        {
            if(context == null) return;

            var entries = context.ChangeTracker.Entries<IEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreationDate").CurrentValue = DateTime.UtcNow;
                    entry.Entity.CreatedBy = authorization.GetCurrentUserId();
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModificationDate = DateTime.UtcNow;
                    entry.Entity.ModifiedBy = authorization.GetCurrentUserId();
                }
            }
        }
    }
}
