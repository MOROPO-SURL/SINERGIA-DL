using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Macroprograms;

internal sealed class MacroprogramCommandRepositoryPortAdapter: AbstractEntityCommandRepositoryPortAdapter<Macroprogram, MacroprogramId, Guid>, IMacroprogramCommandRepositoryPort
{
    public MacroprogramCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
