using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Detail.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Detail.Clipped;

public partial class MilestoneClippedDetailPage : BaseDetailEntityPage<ActionIndicatorMilestoneDetailDtoModel, MilestoneClippedDetailPageModel>
{
    public MilestoneClippedDetailPage(ActionIndicatorMilestoneDetailDtoModel model) : base(new MilestoneClippedDetailPageModel(model))
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