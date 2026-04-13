using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Command.Remove;

internal sealed class ApiKeyRemoveCommandHandler :
    AbstractRemoveCommandHandler<ApiKey, ApiKeyId, Guid, ApiKeyRemoveCommand>,
    IRequestHandler<ApiKeyRemoveCommand>
{
    public ApiKeyRemoveCommandHandler(IApiKeyQueryRepositoryPort entityQueryRepository, IApiKeyCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}