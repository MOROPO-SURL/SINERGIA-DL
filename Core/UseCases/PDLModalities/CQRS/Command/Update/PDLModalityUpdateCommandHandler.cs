using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.Ports;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.CQRS.Command.Update;

internal sealed class PDLModalityUpdateCommandHandler :
    AbstractUpdateCommandHandler<PDLModality, PDLModalityId, Guid, PDLModalityUpdateCommand, PDLModalityDetailDto>,
    IRequestHandler<PDLModalityUpdateCommand, PDLModalityDetailDto>
{
    public PDLModalityUpdateCommandHandler(IPDLModalityCommandRepositoryPort entityCommandRepository, IPDLModalityQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}