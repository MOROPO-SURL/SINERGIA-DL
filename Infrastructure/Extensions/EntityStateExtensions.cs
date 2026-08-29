using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Extensions;

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
