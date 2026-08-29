using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Users;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Users.Mappings;

internal sealed class UserCreateViewModelMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserCreateViewModel, UserCreateCommand>()
            .Map(dest => dest.Roles, src => src.SelectableRoles.Where(item => item.Selected).Select(item => item.Id))
            .Map(dest => dest, src => src);
    }
}
