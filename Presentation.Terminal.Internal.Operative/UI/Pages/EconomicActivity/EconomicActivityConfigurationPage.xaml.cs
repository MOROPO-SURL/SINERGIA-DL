using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.EconomicActivity.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.EconomicActivity;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.EconomicActivity;

public partial class EconomicActivityConfigurationPage : BaseConfigurationEntityPage<EconomicActivityDetailDtoModel, EconomicActivityDetailDtoModel, EconomicActivityConfigurationPageModel>
{
    public EconomicActivityConfigurationPage(EconomicActivityConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Actividad económica";
}