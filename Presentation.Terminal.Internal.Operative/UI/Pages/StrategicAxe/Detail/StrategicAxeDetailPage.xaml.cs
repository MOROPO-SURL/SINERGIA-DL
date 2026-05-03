using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicAxe.Configuration;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicAxe.Detail;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicAxe.Detail;

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