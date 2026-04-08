using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Common.Input;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Users.Mappings;

internal sealed class UserUpdateViewModelMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserDetailDto, UserUpdateViewModel>()
            .Map(dest => dest.SelectableRoles, src => src.Roles.Select(item => new SelectionItemInputViewModel<string>
            {
                Id = item.Id.ToString(),
                Selected = true,
                Label = item.Id.ToString()
            }))
            .Map(dest => dest, src => src);

        config.NewConfig<UserUpdateViewModel, FullUserUpdateCommand>()
            .Map(dest => dest.Roles, src => src.SelectableRoles.Where(item => item.Selected).Select(item => item.Id))
            .Map(dest => dest, src => src);
    }
}
