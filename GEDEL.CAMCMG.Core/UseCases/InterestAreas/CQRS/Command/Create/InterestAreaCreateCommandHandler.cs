using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.DTOs;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Command.Create;

internal sealed class InterestAreaCreateCommandHandler: AbstractCreateCommandHandler<InterestArea, InterestAreaId, Guid, InterestAreaCreateCommand, InterestAreaDetailDto>, IRequestHandler<InterestAreaCreateCommand, InterestAreaDetailDto>
{
    public InterestAreaCreateCommandHandler(IInterestAreaCommandRepositoryPort entityCommandRepository, IInterestAreaQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
