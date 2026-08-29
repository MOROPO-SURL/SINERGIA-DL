using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Detail;

public partial class StrategicProgramDetailPage : BaseDetailEntityPage<StrategicProgramDetailDtoModel, StrategicProgramDetailPageModel>, IDetailItemPageModelPresenter<StrategicProgramDetailDtoModel>
{
	public StrategicProgramDetailPage(StrategicProgramDetailDtoModel model) : base(new StrategicProgramDetailPageModel(model))
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
	}

    public async Task PresentItemModifyUserInterfaceAsync(StrategicProgramDetailDtoModel model, Action<StrategicProgramDetailDtoModel> configurationSuccessCallbackAction)
    {
        StrategicLineQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        StrategicLineBasicDtoModel[] lines = (await apiClient.GetPageAsync(1, 30)).Items;

        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new Configuration.StrategicProgramConfigurationPage(new StrategicProgramConfigurationPageModel(model, lines, configurationSuccessCallbackAction))));
    }
}