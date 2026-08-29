using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Service;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Interceptors.Abstractions;

internal abstract class AbstractChangeDomainTracingInterceptor<TEntityTrace, TEntity, TId, TIdValue> : SaveChangesInterceptor
    where TId : struct, IId<TIdValue>
    where TEntity : AbstractEntity<TId, TIdValue>
    where TEntityTrace : AbstractTrace<TEntity, TId, TIdValue>
{
    protected readonly IDomainChangeAuthorProvisionServicePort traceAuthorProvisionService;

    public AbstractChangeDomainTracingInterceptor(IDomainChangeAuthorProvisionServicePort traceAuthorProvisionService)
    {
        this.traceAuthorProvisionService = traceAuthorProvisionService;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (traceAuthorProvisionService.GetChangeAuthor() is not null)
        {
            EntityEntry<TEntity>[] changeEntries = eventData.Context!.ChangeTracker.Entries<TEntity>().ToArray();

            foreach (EntityEntry<TEntity> changeEntry in changeEntries)
            {
                eventData.Context.Add(BuildTraceEntity(changeEntry));
            };
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    protected abstract TEntityTrace BuildTraceEntity(EntityEntry<TEntity> changeEntry);
}
