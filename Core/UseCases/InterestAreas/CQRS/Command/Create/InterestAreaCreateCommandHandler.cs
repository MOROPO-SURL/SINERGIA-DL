using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.DTOs;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Create;

internal sealed class InterestAreaCreateCommandHandler: AbstractCreateCommandHandler<InterestArea, InterestAreaId, Guid, InterestAreaCreateCommand, InterestAreaDetailDto>, IRequestHandler<InterestAreaCreateCommand, InterestAreaDetailDto>
{
    public InterestAreaCreateCommandHandler(IInterestAreaCommandRepositoryPort entityCommandRepository, IInterestAreaQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
