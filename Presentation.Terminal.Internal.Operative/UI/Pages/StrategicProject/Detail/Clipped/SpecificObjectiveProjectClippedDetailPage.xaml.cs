using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Detail.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Detail.Clipped;

public partial class SpecificObjectiveProjectClippedDetailPage : BaseDetailEntityPage<SpecificObjectiveProjectDetailDtoModel, SpecificObjectiveProjectClippedDetailPageModel>
{
    public SpecificObjectiveProjectClippedDetailPage(SpecificObjectiveProjectDetailDtoModel model) : base(new SpecificObjectiveProjectClippedDetailPageModel(model))
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