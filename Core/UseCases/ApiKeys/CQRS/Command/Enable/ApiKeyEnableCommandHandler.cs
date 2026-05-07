using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Command.Enable;

internal sealed class ApiKeyEnableCommandHandler :
    AbstractEnableCommandHandler<ApiKey, ApiKeyId, Guid, ApiKeyEnableCommand>,
    IRequestHandler<ApiKeyEnableCommand>
{
    public ApiKeyEnableCommandHandler(IApiKeyCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}
