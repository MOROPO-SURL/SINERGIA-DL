using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Macroprograms;

internal sealed class MacroprogramQueryRepositoryPortAdapter: AbstractEntityQueryRepositoryPortAdapter<Macroprogram, MacroprogramId, Guid>, IMacroprogramQueryRepositoryPort
{
    public MacroprogramQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
