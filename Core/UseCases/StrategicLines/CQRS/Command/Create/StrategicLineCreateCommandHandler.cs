using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Create;

internal sealed class StrategicLineCreateCommandHandler : IRequestHandler<StrategicLineCreateCommand, StrategicLineDetailDto>
{
    private readonly IStrategicLineCommandRepositoryPort entityCommandRepository;
    private readonly IStrategicLineQueryRepositoryPort entityQueryRepository;
    private readonly IMapper mapper;

    public StrategicLineCreateCommandHandler(IStrategicLineCommandRepositoryPort entityCommandRepository, IStrategicLineQueryRepositoryPort entityQueryRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<StrategicLineDetailDto> Handle(StrategicLineCreateCommand request, CancellationToken cancellationToken)
    {
        StrategicLine entity = mapper.Map<StrategicLine>(request);

        //await ApplyManualMappingAsync(request, entity);

        await entityCommandRepository.AddAsync(entity);

        return mapper.Map<StrategicLine, StrategicLineDetailDto>(await entityQueryRepository.GetAsync(entity.FirstId, entity.SecoundId));
    }
}