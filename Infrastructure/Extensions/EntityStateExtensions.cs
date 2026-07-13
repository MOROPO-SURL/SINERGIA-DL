using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Extensions;

internal static class EntityStateExtensions
{
    internal static TraceKind ToTraceKind(this EntityState self)
    {
        switch (self) 
        {
            case EntityState.Added: return TraceKind.Creation;

            case EntityState.Modified: return TraceKind.Edition;

            case EntityState.Deleted: return TraceKind.Remotion;

            case EntityState.Unchanged: return TraceKind.Edition;

            default: throw new InvalidOperationException();
        }
    }
}
