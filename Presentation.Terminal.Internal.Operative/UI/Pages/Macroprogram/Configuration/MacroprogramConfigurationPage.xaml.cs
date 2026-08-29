using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Macroprogram;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Macroprogram.Configuration;

public partial class MacroprogramConfigurationPage : BaseConfigurationEntityPage<MacroprogramDetailDtoModel, MacroprogramDetailDtoModel, MacroprogramConfigurationPageModel>
{
	public MacroprogramConfigurationPage(MacroprogramConfigurationPageModel bindingContextModel) : base(bindingContextModel)
	{
		InitializeComponent();
	}

    protected override string EntityTypeName => "Macroprograma";
}