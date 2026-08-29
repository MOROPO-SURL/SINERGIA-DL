using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Authentication.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Authentication.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Models.Authentication.Mappings;

internal sealed class AuthenticateCommandMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationRequestModel, AuthenticateCommand>()
            .Map(dest => dest.AuthenticationType, src => JwtBearerDefaults.AuthenticationScheme)
            .Map(dest => dest, src => src);
    }
}
