using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update;

internal sealed class StrategicLineUpdateCommandHandler : IRequestHandler<StrategicLineUpdateCommand, StrategicLineDetailDto>
{
    private readonly IStrategicLineCommandRepositoryPort entityCommandRepository;
    private readonly IStrategicLineQueryRepositoryPort entityQueryRepository;
    private readonly IMapper mapper;

    public StrategicLineUpdateCommandHandler(IStrategicLineQueryRepositoryPort entityQueryRepository, IStrategicLineCommandRepositoryPort entityCommandRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<StrategicLineDetailDto> Handle(StrategicLineUpdateCommand request, CancellationToken cancellationToken)
    {
        StrategicLine entity = await entityQueryRepository.GetAsync(new StrategicLineId(request.Id), request.AxeId == null ? null : new StrategicAxeId(request.AxeId.Value));

        entityCommandRepository.TrackChanges(entity);

        entity = mapper.Map(request, entity);
        //await ApplyManualMappingAsync(request, entity);
        await entityCommandRepository.UpdateAsync(entity);

        return mapper.Map<StrategicLine, StrategicLineDetailDto>(await entityQueryRepository.GetAsync(entity.FirstId, entity.SecoundId));
    }
}