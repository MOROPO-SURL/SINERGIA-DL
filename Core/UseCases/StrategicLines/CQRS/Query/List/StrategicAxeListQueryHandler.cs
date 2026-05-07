using Mapster;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Query.List;

internal sealed class StrategicLineListQueryHandler : IRequestHandler<StrategicLineListQuery, StrategicLineDetailDto[]>
{
    private readonly IStrategicLineQueryRepositoryPort entityQueryRepository;

    public StrategicLineListQueryHandler(IStrategicLineQueryRepositoryPort entityQueryRepository)
    {
        this.entityQueryRepository = entityQueryRepository;
    }

    public Task<StrategicLineDetailDto[]> Handle(StrategicLineListQuery request, CancellationToken cancellationToken)
    {
        if (request.Criteria != null)
        {
            return Task.FromResult(entityQueryRepository!.GetFindByQueryable(request.Criteria!).ProjectToType<StrategicLineDetailDto>().ToArray());
        }

        return Task.FromResult(entityQueryRepository!.GetAllQueryable().ProjectToType<StrategicLineDetailDto>().ToArray());
    }
}