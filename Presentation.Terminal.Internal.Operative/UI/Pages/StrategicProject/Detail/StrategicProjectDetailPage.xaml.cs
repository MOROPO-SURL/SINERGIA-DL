using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProjectKind.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Detail;

public partial class StrategicProjectDetailPage : BaseDetailEntityPage<StrategicProjectDetailDtoModel, StrategicProjectDetailPageModel>, IDetailItemPageModelPresenter<StrategicProjectDetailDtoModel>
{
	public StrategicProjectDetailPage(StrategicProjectDetailDtoModel model) : base(new StrategicProjectDetailPageModel(model))
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
	}

    public async Task PresentItemModifyUserInterfaceAsync(StrategicProjectDetailDtoModel model, Action<StrategicProjectDetailDtoModel> configurationSuccessCallbackAction)
    {
        IHttpClientProviderPort httpClientProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

        StrategicProjectKindQueryApiClient projectKindApiClient = new(httpClientProvider);
        StrategicProgramQueryApiClient programApiClient = new(httpClientProvider);

        StrategicProjectKindBasicDtoModel[] kinds = (await projectKindApiClient.GetPageAsync(1, 30)).Items;
        StrategicProgramBasicDtoModel[] programs = (await programApiClient.GetPageAsync(1, 100)).Items;

        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new Configuration.StrategicProjectConfigurationPage(new StrategicProjectConfigurationPageModel(model, kinds, programs, configurationSuccessCallbackAction))));
    }
}