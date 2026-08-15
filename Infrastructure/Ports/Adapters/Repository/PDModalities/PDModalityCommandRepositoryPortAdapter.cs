using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.Ports;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.PDLModalities;

internal sealed class PDLModalityCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<PDLModality, PDLModalityId, Guid>, IPDLModalityCommandRepositoryPort
{
    public PDLModalityCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}