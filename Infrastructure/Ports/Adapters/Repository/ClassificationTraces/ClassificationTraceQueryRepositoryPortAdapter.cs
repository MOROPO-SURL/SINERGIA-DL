using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ClassificationTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.ClassificationTraces;

internal sealed class ClassificationTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<ClassificationTrace, TraceId, long>, IClassificationTraceQueryRepositoryPort
{
    public ClassificationTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}