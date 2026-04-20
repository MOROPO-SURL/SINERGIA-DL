using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Common.Input;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Roles.Mappings;

internal sealed class RoleUpdateViewModelMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RoleDetailDto, RoleUpdateViewModel>()
            .Map(dest => dest.SelectedPermissions, src => src.Permissions.Select(item => new SelectionDescriptedItemInputViewModel<string>
            {
                Id = item.Id,
                Selected = true,
                Label = item.Id,
                Description = item.Description
            }))
            .Map(dest => dest, src => src);

        config.NewConfig<RoleUpdateViewModel, RoleUpdateCommand>()
            .Map(dest => dest.Permissions, src => src.SelectedPermissions.Where(item => item.Selected).Select(item => item.Id))
            .Map(dest => dest, src => src);
    }
}
