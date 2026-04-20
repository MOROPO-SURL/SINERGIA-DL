using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.Mappings;

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
