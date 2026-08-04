using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.Ports;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.CQRS.Command.Remove;

internal sealed class PDLModalityRemoveCommandHandler :
    AbstractRemoveCommandHandler<PDLModality, PDLModalityId, Guid, PDLModalityRemoveCommand>,
    IRequestHandler<PDLModalityRemoveCommand>
{
    public PDLModalityRemoveCommandHandler(IPDLModalityCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}