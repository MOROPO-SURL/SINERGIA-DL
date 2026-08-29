using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarrierTraces.Ports.Repository;

public interface ITerritorialBarrierTraceQueryRepositoryPort : IEntityQueryRepositoryPort<TerritorialBarrierTrace, TraceId, long>
{
}