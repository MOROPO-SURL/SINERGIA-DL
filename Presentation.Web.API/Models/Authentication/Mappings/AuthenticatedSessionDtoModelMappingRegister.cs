using Mapster;
using Microsoft.Extensions.Options;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Authentication.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Authentication.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Configurations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Extensions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Models.Authentication.Mappings;

internal sealed class AuthenticatedSessionDtoModelMappingRegister : IRegister
{
    private readonly IOptions<JWTConfiguration> jwtConfigurationOptions;

    public AuthenticatedSessionDtoModelMappingRegister(IOptions<JWTConfiguration> jwtConfigurationOptions)
    {
        this.jwtConfigurationOptions = jwtConfigurationOptions;
    }

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationIdentityDto, AuthenticatedSessionDtoModel>()
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
