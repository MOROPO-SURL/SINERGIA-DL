using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Query.Detail;

internal sealed class StrategicLineDetailQueryHandler : IRequestHandler<StrategicLineDetailQuery, StrategicLineDetailDto>
{
    private readonly IStrategicLineQueryRepositoryPort entityQueryRepository;
    private readonly IMapper mapper;

    public StrategicLineDetailQueryHandler(IStrategicLineQueryRepositoryPort entityQueryRepository, IMapper mapper)
    {
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<StrategicLineDetailDto> Handle(StrategicLineDetailQuery request, CancellationToken cancellationToken)
    {
        StrategicLine entity = await entityQueryRepository.GetAsync(new StrategicLineId(request.Id), new StrategicAxeId(request.AxeId));

        return mapper.Map<StrategicLineDetailDto>(entity);
    }
}