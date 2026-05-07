using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Detail;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Detail;

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