using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Person;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Configuration;

public partial class StrategicProgramConfigurationPage : BaseConfigurationEntityPage<StrategicProgramDetailDtoModel, StrategicProgramDetailDtoModel, StrategicProgramConfigurationPageModel>
{
	public StrategicProgramConfigurationPage(StrategicProgramConfigurationPageModel bindingContextModel) : base(bindingContextModel)
	{
		InitializeComponent();
	}

    protected override string EntityTypeName => "Programa";

    private void CoordinatorPickButton_Clicked(object sender, EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new NavigationPage(new PersonPickPage(CoordinatorPicked_Callback)));
    }

    private void CoordinatorPicked_Callback(PersonBasicDtoModel model)
    {
        ConcreteBindingContext.Coordinator = model;
    }
}