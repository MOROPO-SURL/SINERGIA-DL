using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Command.Create;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.ApiKeys.Mappings;

internal sealed class ApiKeyCreateViewModelMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ApiKeyCreateViewModel, ApiKeyCreateCommand>()
            .Map(dest => dest.Permissions, src => src.SelectedPermissions.Where(item => item.Selected).Select(item => item.Id))
            .Map(dest => dest, src => src);
    }
}
