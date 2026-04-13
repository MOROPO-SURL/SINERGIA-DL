using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Common.Input;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.ApiKeys.Mappings;

internal sealed class ApiKeyUpdateViewModelMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ApiKeyDetailDto, ApiKeyUpdateViewModel>()
            .Map(dest => dest.SelectedPermissions, src => src.Permissions.Select(item => new SelectionDescriptedItemInputViewModel<string>
            {
                Id = item.Id,
                Selected = true,
                Label = item.Id,
                Description = item.Description
            }))
            .Map(dest => dest, src => src);

        config.NewConfig<ApiKeyUpdateViewModel, ApiKeyUpdateCommand>()
            .Map(dest => dest.Permissions, src => src.SelectedPermissions.Where(item => item.Selected).Select(item => item.Id))
            .Map(dest => dest, src => src);
    }
}
