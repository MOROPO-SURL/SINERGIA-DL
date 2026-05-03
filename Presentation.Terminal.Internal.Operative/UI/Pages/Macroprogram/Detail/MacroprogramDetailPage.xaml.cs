using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Macroprogram.Configuration;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Macroprogram.Detail;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Macroprogram.Detail;

public partial class MacroprogramDetailPage : BaseDetailEntityPage<MacroprogramDetailDtoModel, MacroprogramDetailPageModel>, IDetailItemPageModelPresenter<MacroprogramDetailDtoModel>
{
	public MacroprogramDetailPage(MacroprogramDetailDtoModel model) : base(new MacroprogramDetailPageModel(model))
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
	}

    public Task PresentItemModifyUserInterfaceAsync(MacroprogramDetailDtoModel model, Action<MacroprogramDetailDtoModel> configurationSuccessCallbackAction)
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new Configuration.MacroprogramConfigurationPage(new MacroprogramConfigurationPageModel(model, configurationSuccessCallbackAction))));

        return Task.CompletedTask;
    }
}