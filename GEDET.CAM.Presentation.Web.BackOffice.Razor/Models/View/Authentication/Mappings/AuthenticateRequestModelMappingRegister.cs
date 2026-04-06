using Mapster;
using Microsoft.AspNetCore.Authentication.Cookies;
using MOROPO.GEDET.CAM.Core.UseCases.Authentication.CQRS.Command;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Authentication.Mappings;

public sealed class AuthenticateRequestModelMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticateRequestModel, AuthenticateCommand>()
            .Map(dest => dest.AuthenticationType, src => CookieAuthenticationDefaults.AuthenticationScheme)
            .Map(dest => dest.Key, src => src.UserName)
            .Map(dest => dest, src => src);
    }
}
