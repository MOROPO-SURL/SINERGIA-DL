using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Command.Disable;

internal sealed class ApiKeyDisableCommandHandler :
    AbstractDisableCommandHandler<ApiKey, ApiKeyId, Guid, ApiKeyDisableCommand>,
    IRequestHandler<ApiKeyDisableCommand>
{
    public ApiKeyDisableCommandHandler(IApiKeyCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}
