using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Constants;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Service;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Interceptors;

internal sealed class MacroprogramChangeDomainTracingInterceptor : Abstractions.AbstractChangeDomainTracingInterceptor<MacroprogramTrace, Macroprogram, MacroprogramId, Guid>
{
    public MacroprogramChangeDomainTracingInterceptor(IDomainChangeAuthorProvisionServicePort traceAuthorProvisionService) : base(traceAuthorProvisionService)
    {
    }

    protected override MacroprogramTrace BuildTraceEntity(EntityEntry<Macroprogram> changeEntry)
    {
        return new MacroprogramTrace(
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
