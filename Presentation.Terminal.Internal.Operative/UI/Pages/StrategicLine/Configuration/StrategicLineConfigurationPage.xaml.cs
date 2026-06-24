using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Configuration;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicLine.Configuration;

public partial class StrategicLineConfigurationPage : BaseConfigurationEntityPage<StrategicLineBasicDtoModel, StrategicLineDetailDtoModel, StrategicLineConfigurationPageModel>
{
	public StrategicLineConfigurationPage(StrategicLineConfigurationPageModel bindingContextModel) : base(bindingContextModel)
	{
		InitializeComponent();
	}

    protected override string EntityTypeName => "Línea estratégica";

    private void CoordinatorPickButton_Clicked(object sender, EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new NavigationPage(new Person.PersonPickPage(CoordinatorPicked_Callback)));
    }

    private void CoordinatorPicked_Callback(PersonBasicDtoModel model)
    {
        ConcreteBindingContext.Coordinator = model;
    }
}