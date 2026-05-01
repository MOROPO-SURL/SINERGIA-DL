using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Constants;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Service;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Interceptors;

internal sealed class RoleChangeDomainTracingInterceptor : Abstractions.AbstractChangeDomainTracingInterceptor<RoleTrace, Role, RoleId, Guid>
{
    private readonly IDomainChangeAuthorProvisionServicePort traceAuthorProvisionService;

    public RoleChangeDomainTracingInterceptor(IDomainChangeAuthorProvisionServicePort traceAuthorProvisionService)
    {
        this.traceAuthorProvisionService = traceAuthorProvisionService;
    }

    protected override RoleTrace BuildTraceEntity(EntityEntry<Role> changeEntry)
    {
        return new RoleTrace(
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
