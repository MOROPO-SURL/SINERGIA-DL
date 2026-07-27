using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicProjectIdeas;

internal sealed class StrategicProjectIdeaCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<StrategicProjectIdea, StrategicProjectIdeaId, Guid>, IStrategicProjectIdeaCommandRepositoryPort
{
    public StrategicProjectIdeaCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}