using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Command.Update;

internal sealed class ApiKeyUpdateCommandHandler :
    AbstractUpdateCommandHandler<ApiKey, ApiKeyId, Guid, ApiKeyUpdateCommand, ApiKeyDetailDto>,
    IRequestHandler<ApiKeyUpdateCommand, ApiKeyDetailDto>
{
    private readonly IDataIntegrityServicePort dataIntegrityService;
    private readonly IApiKeyPermissionBridgeCommandRepositoryPort permissionBridgeCommandRepository;

    public ApiKeyUpdateCommandHandler(IApiKeyQueryRepositoryPort entityQueryRepository, IApiKeyCommandRepositoryPort entityCommandRepository, IMapper mapper, IDataIntegrityServicePort dataIntegrityService, IApiKeyPermissionBridgeCommandRepositoryPort permissionBridgeCommandRepository)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.dataIntegrityService = dataIntegrityService;
        this.permissionBridgeCommandRepository = permissionBridgeCommandRepository;
    }

    protected override async Task ApplyManualMappingAsync(ApiKeyUpdateCommand request, ApiKey entity)
    {
        List<ApiKeyPermissionBridge> outgoins = [.. entity.PermissionBridges];

        foreach (var item in request.Permissions!)
        {
            if (outgoins.Any(bridge => bridge.LinkedId.Value == item))
            {
                outgoins.Remove(outgoins.First(bridge => bridge.LinkedId.Value == item));

                continue;
            }

            var bridge = new ApiKeyPermissionBridge(entity.Id, new PermissionId(item));

            bridge.Signature = await dataIntegrityService.GetEntitySignatureAsync(bridge);

            entity.PermissionBridges.Add(await permissionBridgeCommandRepository.AddAsync(bridge, false));
        }

        foreach (var item in outgoins)
        {
            await permissionBridgeCommandRepository.DeleteAsync(item, false);
        }
    }
}