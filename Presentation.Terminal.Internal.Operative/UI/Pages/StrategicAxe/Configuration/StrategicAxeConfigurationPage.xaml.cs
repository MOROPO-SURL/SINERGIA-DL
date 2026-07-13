using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicAxe.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicAxe.Configuration;

public partial class StrategicAxeConfigurationPage : BaseConfigurationEntityPage<StrategicAxeBasicDtoModel, StrategicAxeDetailDtoModel, StrategicAxeConfigurationPageModel>
{
	public StrategicAxeConfigurationPage(StrategicAxeConfigurationPageModel bindingContextModel) : base(bindingContextModel)
	{
		InitializeComponent();
	}

    protected override string EntityTypeName => "Eje estratégico";

    private void CoordinatorPickButton_Clicked(object sender, EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new NavigationPage(new Person.PersonPickPage(CoordinatorPicked_Callback)));
    }

    private void CoordinatorPicked_Callback(PersonBasicDtoModel model)
    {
        ConcreteBindingContext.Coordinator = model;
    }
}