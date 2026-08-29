using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Command.Create;

internal sealed class PDLModalityCreateCommandHandler :
    AbstractCreateCommandHandler<PDLModality, PDLModalityId, Guid, PDLModalityCreateCommand, PDLModalityDetailDto>,
    IRequestHandler<PDLModalityCreateCommand, PDLModalityDetailDto>
{
    public PDLModalityCreateCommandHandler(IPDLModalityCommandRepositoryPort entityCommandRepository, IPDLModalityQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}