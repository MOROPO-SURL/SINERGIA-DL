using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicProjectIdeas;

internal sealed class StrategicProjectIdeaCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<StrategicProjectIdea, StrategicProjectIdeaId, Guid>, IStrategicProjectIdeaCommandRepositoryPort
{
    public StrategicProjectIdeaCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}