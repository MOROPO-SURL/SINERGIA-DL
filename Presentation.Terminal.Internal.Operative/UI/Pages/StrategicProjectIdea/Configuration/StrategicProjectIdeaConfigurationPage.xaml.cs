using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectIdea.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProjectIdea.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProjectIdea.Configuration;

public partial class StrategicProjectIdeaConfigurationPage : BaseConfigurationEntityPage<StrategicProjectIdeaDetailDtoModel, StrategicProjectIdeaDetailDtoModel, StrategicProjectIdeaConfigurationPageModel>
{
	public StrategicProjectIdeaConfigurationPage(StrategicProjectIdeaConfigurationPageModel bindingContextModel) : base(bindingContextModel)
	{
		InitializeComponent();
	}

    protected override string EntityTypeName => "Idea de proyecto";
}