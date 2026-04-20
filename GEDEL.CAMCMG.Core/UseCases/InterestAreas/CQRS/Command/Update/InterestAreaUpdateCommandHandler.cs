using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.DTOs;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Command.Update;

internal sealed class InterestAreaUpdateCommandHandler: AbstractUpdateCommandHandler<InterestArea, InterestAreaId, Guid, InterestAreaUpdateCommand, InterestAreaDetailDto>,
    IRequestHandler<InterestAreaUpdateCommand, InterestAreaDetailDto>
{
    public InterestAreaUpdateCommandHandler(IInterestAreaCommandRepositoryPort entityCommandRepository, IInterestAreaQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
