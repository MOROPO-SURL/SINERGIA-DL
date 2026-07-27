using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProjectIdea.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProjectIdea.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProjectIdea.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProjectIdea.Detail;

public partial class StrategicProjectIdeaDetailPage : BaseDetailEntityPage<StrategicProjectIdeaDetailDtoModel, StrategicProjectIdeaDetailPageModel>, IDetailItemPageModelPresenter<StrategicProjectIdeaDetailDtoModel>
{
	public StrategicProjectIdeaDetailPage(StrategicProjectIdeaDetailDtoModel model) : base(new StrategicProjectIdeaDetailPageModel(model))
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
	}

    public async Task PresentItemModifyUserInterfaceAsync(StrategicProjectIdeaDetailDtoModel model, Action<StrategicProjectIdeaDetailDtoModel> configurationSuccessCallbackAction)
    {
        IHttpClientProviderPort httpClientProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

        StrategicProgramQueryApiClient programApiClient = new(httpClientProvider);

        StrategicProgramBasicDtoModel[] programs = (await programApiClient.GetPageAsync(1, 100)).Items;

        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new Configuration.StrategicProjectIdeaConfigurationPage(new StrategicProjectIdeaConfigurationPageModel(model, programs, configurationSuccessCallbackAction))));
    }
}