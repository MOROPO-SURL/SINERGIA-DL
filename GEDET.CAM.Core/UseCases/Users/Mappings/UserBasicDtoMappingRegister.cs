using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.Mappings;

internal class UserBasicDtoMappingRegister : IRegister
{
    private readonly IDataIntegrityServicePort dataIntegrityService;

    public UserBasicDtoMappingRegister(IDataIntegrityServicePort dataIntegrityService)
    {
        this.dataIntegrityService = dataIntegrityService;
    }

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.IsIntegrityAssured, src => ToIsIntegrityAssuredAsync(dataIntegrityService, src))
            .Map(dest => dest, src => src);
    }

    private static bool ToIsIntegrityAssuredAsync(IDataIntegrityServicePort dataIntegrityService, User user)
    {
        var signature = dataIntegrityService.GetEntitySignatureAsync(user).GetAwaiter().GetResult();

        return user.Signature == signature;
    }
}
