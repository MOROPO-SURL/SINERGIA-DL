using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicLine.Detail;

public partial class StrategicLineDetailPage : BaseDetailEntityPage<StrategicLineDetailDtoModel, StrategicLineDetailPageModel>, IDetailItemPageModelPresenter<StrategicLineDetailDtoModel>
{
	public StrategicLineDetailPage(StrategicLineDetailDtoModel model) : base(new StrategicLineDetailPageModel(model))
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
	}

    public async Task PresentItemModifyUserInterfaceAsync(StrategicLineDetailDtoModel model, Action<StrategicLineDetailDtoModel> configurationSuccessCallbackAction)
    {
        StrategicAxeQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        StrategicAxeBasicDtoModel[] axes = (await apiClient.GetPageAsync(1, 30)).Items;

        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new Configuration.StrategicLineConfigurationPage(new StrategicLineConfigurationPageModel(model, axes, configurationSuccessCallbackAction))));
    }
}