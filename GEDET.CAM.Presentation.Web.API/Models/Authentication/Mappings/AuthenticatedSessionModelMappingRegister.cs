using Mapster;
using Microsoft.Extensions.Options;
using MOROPO.GEDET.CAM.Core.UseCases.Authentication.DTOs;
using MOROPO.GEDET.CAM.Interop.Contracts.Models.Authentication.DTOs;
using MOROPO.GEDET.CAM.Presentation.Web.API.Extensions;

namespace MOROPO.GEDET.CAM.Presentation.Web.API.Models.Authentication.Mappings;

internal sealed class AuthenticatedSessionModelMappingRegister : IRegister
{
    private readonly IOptions<Configurations.JWTConfiguration> jwtConfigurationOptions;

    public AuthenticatedSessionModelMappingRegister(IOptions<Configurations.JWTConfiguration> jwtConfigurationOptions)
    {
        this.jwtConfigurationOptions = jwtConfigurationOptions;
    }

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationIdentityDto, AuthenticatedSessionModel>()
            .Map(dest => dest.AuthenticationType, src => src.Identity.AuthenticationType)
            .Map(dest => dest.AuthorizationToken, src => src.Identity.ToBearerToken(jwtConfigurationOptions))
            .Map(dest => dest.SessionExpirationInSecond, src => jwtConfigurationOptions.Value.ExpiresInSecond)
            .Map(dest => dest.User, src => src.UserDetail);
    }
}
