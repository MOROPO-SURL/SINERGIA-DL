using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Feature.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Feature;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Feature;

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