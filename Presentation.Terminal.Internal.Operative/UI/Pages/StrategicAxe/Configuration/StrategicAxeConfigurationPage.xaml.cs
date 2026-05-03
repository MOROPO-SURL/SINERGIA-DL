using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicAxe.Configuration;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicAxe.Configuration;

public partial class StrategicAxeConfigurationPage : BaseConfigurationEntityPage<StrategicAxeBasicDtoModel, StrategicAxeDetailDtoModel, StrategicAxeConfigurationPageModel>
{
	public StrategicAxeConfigurationPage(StrategicAxeConfigurationPageModel bindingContextModel) : base(bindingContextModel)
	{
		InitializeComponent();
	}

    protected override string EntityTypeName => "Eje estratégico";
}