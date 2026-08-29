using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Constants;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Service;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Interceptors;

internal sealed class StrategicProgramChangeDomainTracingInterceptor : Abstractions.AbstractChangeDomainTracingInterceptor<StrategicProgramTrace, StrategicProgram, StrategicProgramId, Guid>
{
    public StrategicProgramChangeDomainTracingInterceptor(IDomainChangeAuthorProvisionServicePort traceAuthorProvisionService) : base(traceAuthorProvisionService)
    {
    }

    protected override StrategicProgramTrace BuildTraceEntity(EntityEntry<StrategicProgram> changeEntry)
    {
        return new StrategicProgramTrace(
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