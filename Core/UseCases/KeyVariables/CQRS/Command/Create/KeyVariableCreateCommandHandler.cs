using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Create;

internal sealed class KeyVariableCreateCommandHandler :
    AbstractCreateCommandHandler<KeyVariable, KeyVariableId, Guid, KeyVariableCreateCommand, KeyVariableDetailDto>,
    IRequestHandler<KeyVariableCreateCommand, KeyVariableDetailDto>
{
    public KeyVariableCreateCommandHandler(IKeyVariableCommandRepositoryPort entityCommandRepository, IKeyVariableQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}