using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Command.Enable;

internal sealed class PDLModalityEnableCommandHandler :
    AbstractEnableCommandHandler<PDLModality, PDLModalityId, Guid, PDLModalityEnableCommand>,
    IRequestHandler<PDLModalityEnableCommand>
{
    public PDLModalityEnableCommandHandler(IPDLModalityCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}