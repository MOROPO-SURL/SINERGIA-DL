using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Person;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicAxe.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicAxe.Configuration;

public partial class StrategicAxeConfigurationPage : BaseConfigurationEntityPage<StrategicAxeDetailDtoModel, StrategicAxeDetailDtoModel, StrategicAxeConfigurationPageModel>
{
	public StrategicAxeConfigurationPage(StrategicAxeConfigurationPageModel bindingContextModel) : base(bindingContextModel)
	{
		InitializeComponent();
	}

    protected override string EntityTypeName => "Eje estratégico";

    private void CoordinatorPickButton_Clicked(object sender, EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new NavigationPage(new PersonPickPage(CoordinatorPicked_Callback)));
    }

    private void CoordinatorPicked_Callback(PersonBasicDtoModel model)
    {
        ConcreteBindingContext.Coordinator = model;
    }
}