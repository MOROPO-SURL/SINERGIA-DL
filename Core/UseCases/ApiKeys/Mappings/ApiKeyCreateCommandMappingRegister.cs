using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.Mappings;

internal sealed class ApiKeyCreateCommandMappingRegister : IRegister
{
    private readonly IStringHashingServicePort stringHashingService;

    public ApiKeyCreateCommandMappingRegister(IStringHashingServicePort stringHashingService)
    {
        this.stringHashingService = stringHashingService;
    }

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ApiKeyCreateCommand, ApiKey>()
            .Map(dest => dest.Id, src => new ApiKeyId(Guid.NewGuid()))
            .Map(dest => dest.Token, src => stringHashingService.GetHashed($"{Guid.NewGuid()}_{DateTime.Now.Ticks}"))
            .Map(dest => dest, src => src);
    }
}
