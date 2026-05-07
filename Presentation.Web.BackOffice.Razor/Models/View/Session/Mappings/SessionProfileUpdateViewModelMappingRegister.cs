using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Users;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Session.Mappings;

internal sealed class SessionProfileUpdateViewModelMappingRegister : IRegister
{
    private readonly IHttpContextAccessor contextAccessor;

    public SessionProfileUpdateViewModelMappingRegister(IHttpContextAccessor contextAccessor)
    {
        this.contextAccessor = contextAccessor;
    }

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SessionProfileUpdateViewModel, EssentialUserUpdateCommand>()
            .Map(dest => dest.Id, src => contextAccessor.HttpContext!.User.Identity!.Name)
            .Map(dest => dest, src => src);
    }
}
