using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Macroprogram.Detail;

public sealed class MacroprogramDetailPageModel : AbstractDetailEntityPageModel<MacroprogramDetailDtoModel>
{
    public MacroprogramDetailPageModel(MacroprogramDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
    }

    protected override async Task PerformRemotionAsync(MacroprogramDetailDtoModel model)
    {
        MacroprogramCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        await apiClient.ArchiveAsync(model.Id);
    }
}