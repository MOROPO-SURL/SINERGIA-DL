using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Detail.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Detail.Clipped;

public partial class IndicatorClippedDetailPage : BaseDetailEntityPage<ActionIndicatorDetailDtoModel, IndicatorClippedDetailPageModel>
{
    public IndicatorClippedDetailPage(ActionIndicatorDetailDtoModel model) : base(new IndicatorClippedDetailPageModel(model))
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        DismissControl_Invoked(this, EventArgs.Empty);

        return true;
    }

    protected void DismissControl_Invoked(object sender, EventArgs eventArgs)
    {
        this.NavigationPopModalPageAsync();
    }
}