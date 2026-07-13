using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.EconomicActivity.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.EconomicActivity;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.EconomicActivity;

public partial class EconomicActivityDetailPage : BaseDetailEntityPage<EconomicActivityDetailDtoModel, EconomicActivityDetailPageModel>, IDetailItemPageModelPresenter<EconomicActivityDetailDtoModel>
{
    public EconomicActivityDetailPage(EconomicActivityDetailDtoModel model) : base(new EconomicActivityDetailPageModel(model))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemModifyUserInterfaceAsync(EconomicActivityDetailDtoModel model, Action<EconomicActivityDetailDtoModel> configurationSuccessCallbackAction)
    {
        EconomicActivityQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        EconomicActivityConfigurationPageModel _model = new(model, configurationSuccessCallbackAction, new Validators.EconomicActivityConfigurationValidator());

        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new EconomicActivityConfigurationPage(_model)));

        return Task.CompletedTask;
    }
}