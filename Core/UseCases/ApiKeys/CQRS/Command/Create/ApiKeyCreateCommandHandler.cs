using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PermissionAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Command.Create;

internal sealed class ApiKeyCreateCommandHandler :
    AbstractCreateCommandHandler<ApiKey, ApiKeyId, Guid, ApiKeyCreateCommand, ApiKeyDetailDto>,
    IRequestHandler<ApiKeyCreateCommand, ApiKeyDetailDto>
{
    private readonly IDataIntegrityServicePort dataIntegrityService;

    public ApiKeyCreateCommandHandler(IApiKeyCommandRepositoryPort entityCommandRepository, IApiKeyQueryRepositoryPort entityQueryRepository, IMapper mapper, IDataIntegrityServicePort dataIntegrityService)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.dataIntegrityService = dataIntegrityService;
    }

    protected override async Task PerformPreCreateAsync(ApiKeyCreateCommand request, ApiKey entity)
    {
        foreach (var item in request.Permissions!)
        {
            var bridge = new Domain.Bridges.ApiKeyPermissionBridge(entity.Id, new PermissionId(item));

            bridge.Signature = await dataIntegrityService.GetEntitySignatureAsync(bridge);

            entity.PermissionBridges.Add(bridge);
        }
    }
}