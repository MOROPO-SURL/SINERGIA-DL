using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Constants;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Service;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Interceptors;

internal sealed class EconomicActivityChangeDomainTracingInterceptor : Abstractions.AbstractChangeDomainTracingInterceptor<EconomicActivityTrace, EconomicActivity, EconomicActivityId, int>
{
    public EconomicActivityChangeDomainTracingInterceptor(IDomainChangeAuthorProvisionServicePort traceAuthorProvisionService) : base(traceAuthorProvisionService)
    {
    }

    protected override EconomicActivityTrace BuildTraceEntity(EntityEntry<EconomicActivity> changeEntry)
    {
        return new EconomicActivityTrace(
            new Domain.Aggretates.TraceAggregate.Values.TraceId(default),
            changeEntry.State.ToTraceKind(),
            traceAuthorProvisionService.GetChangeAuthor() ?? TracingConstants.DEFAULT_AUTHOR,
            DateTime.Now,
            string.Empty,
            changeEntry.State == EntityState.Added ? null : System.Text.Json.JsonSerializer.Serialize(changeEntry.OriginalValues.ToObject()),
            changeEntry.State == EntityState.Deleted ? null : System.Text.Json.JsonSerializer.Serialize(changeEntry.CurrentValues.ToObject()),
            changeEntry.Entity.Id,
            changeEntry.Entity);
    }
}
