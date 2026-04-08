using Mapster;
using Microsoft.Extensions.Options;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Authentication.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Configurations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Extensions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Authentication.Mappings;

internal sealed class AuthenticatedSessionModelMappingRegister : IRegister
{
    private readonly IOptions<JWTConfiguration> jwtConfigurationOptions;

    public AuthenticatedSessionModelMappingRegister(IOptions<JWTConfiguration> jwtConfigurationOptions)
    {
        this.jwtConfigurationOptions = jwtConfigurationOptions;
    }

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationIdentityDto, AuthenticatedSessionModel>()
            .Map(dest => dest.AuthenticationType, src => src.Identity.AuthenticationType)
            .Map(dest => dest.AuthorizationToken, src => src.Identity.ToBearerToken(jwtConfigurationOptions))
            .Map(dest => dest.SessionExpirationInSecond, src => jwtConfigurationOptions.Value.ExpiresInSecond)
            .Map(dest => dest.HasFullAccess, src => src.UserDetail.HasFullAccess)
            .Map(dest => dest.Permissions, src => RolesToPermisssions(src.UserDetail))
            .Map(dest => dest.User, src => src.UserDetail);
    }

    private static string[] RolesToPermisssions(UserDetailDto dto)
    {
        List<string> permissions = [];

        foreach (var role in dto.Roles)
        {
            permissions.AddRange(role.Permissions.Select(permission => permission.Id));
        }

        return [.. permissions];
    }
}
