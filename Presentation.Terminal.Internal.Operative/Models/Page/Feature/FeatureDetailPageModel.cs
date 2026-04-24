using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Feature.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Feature;

public sealed class FeatureDetailPageModel : AbstractDetailEntityPageModel<FeatureDetailDtoModel>
{
    public FeatureDetailPageModel(FeatureDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
    }

    protected override async Task PerformRemotionAsync(FeatureDetailDtoModel model)
    {
        FeatureCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        await apiClient.DeleteAsync(model.Id);
    }
}