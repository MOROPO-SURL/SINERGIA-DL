using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicAxe.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicAxe.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicAxe.Detail;

public partial class StrategicAxeDetailPage : BaseDetailEntityPage<StrategicAxeDetailDtoModel, StrategicAxeDetailPageModel>, IDetailItemPageModelPresenter<StrategicAxeDetailDtoModel>
{
	public StrategicAxeDetailPage(StrategicAxeDetailDtoModel model) : base(new StrategicAxeDetailPageModel(model))
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
	}

    public Task PresentItemModifyUserInterfaceAsync(StrategicAxeDetailDtoModel model, Action<StrategicAxeDetailDtoModel> configurationSuccessCallbackAction)
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new Configuration.StrategicAxeConfigurationPage(new StrategicAxeConfigurationPageModel(model, configurationSuccessCallbackAction))));

        return Task.CompletedTask;
    }
}