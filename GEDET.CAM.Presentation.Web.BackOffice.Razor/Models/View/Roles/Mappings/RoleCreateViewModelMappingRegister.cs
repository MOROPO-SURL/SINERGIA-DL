using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Create;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Roles.Mappings;

internal sealed class RoleCreateViewModelMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RoleCreateViewModel, RoleCreateCommand>()
            .Map(dest => dest.Permissions, src => src.SelectedPermissions.Where(item => item.Selected).Select(item => item.Id))
            .Map(dest => dest, src => src);
    }
}
