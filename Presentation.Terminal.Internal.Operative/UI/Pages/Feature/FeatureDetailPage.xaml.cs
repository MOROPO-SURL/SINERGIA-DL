using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Feature.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Feature;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Feature;

public partial class FeatureDetailPage : BaseDetailEntityPage<FeatureDetailDtoModel, FeatureDetailPageModel>, IDetailItemPageModelPresenter<FeatureDetailDtoModel>
{
    public FeatureDetailPage(FeatureDetailDtoModel model) : base(new FeatureDetailPageModel(model))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemModifyUserInterfaceAsync(FeatureDetailDtoModel model, Action<FeatureDetailDtoModel> configurationSuccessCallbackAction)
    {
        FeatureKindQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        FeatureConfigurationPageModel _model = new(model, configurationSuccessCallbackAction)
        {
            AvailableKinds = [.. (await apiClient.GetPageAsync(1, 30)).Items]
        };

        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new FeatureConfigurationPage(_model)));
    }
}