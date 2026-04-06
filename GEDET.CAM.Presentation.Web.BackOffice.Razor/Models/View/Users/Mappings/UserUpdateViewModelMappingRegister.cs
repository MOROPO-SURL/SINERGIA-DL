using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Update;
using MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;
using MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Common.Input;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Users.Mappings;

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
