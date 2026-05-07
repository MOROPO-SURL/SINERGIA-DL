using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Configuration;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Detail;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicLine.Detail;

public partial class StrategicLineDetailPage : BaseDetailEntityPage<StrategicLineDetailDtoModel, StrategicLineDetailPageModel>, IDetailItemPageModelPresenter<StrategicLineDetailDtoModel>
{
	public StrategicLineDetailPage(StrategicLineDetailDtoModel model) : base(new StrategicLineDetailPageModel(model))
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
	}

    public Task PresentItemModifyUserInterfaceAsync(StrategicLineDetailDtoModel model, Action<StrategicLineDetailDtoModel> configurationSuccessCallbackAction)
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new Configuration.StrategicLineConfigurationPage(new StrategicLineConfigurationPageModel(model, [model.StrategicAxe], configurationSuccessCallbackAction))));

        return Task.CompletedTask;
    }
}