using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.PDLModalities;

internal sealed class PDLModalityQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<PDLModality, PDLModalityId, Guid>, IPDLModalityQueryRepositoryPort
{
    public PDLModalityQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}