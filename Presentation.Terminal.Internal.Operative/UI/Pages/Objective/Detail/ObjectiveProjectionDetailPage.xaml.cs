using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Detail;

public partial class ObjectiveProjectionDetailPage : BaseDetailEntityPage<ObjectiveProjectionDetailDtoModel, ObjectiveProjectionDetailPageModel>
{
    public ObjectiveProjectionDetailPage(ObjectiveProjectionDetailDtoModel model) : base(new ObjectiveProjectionDetailPageModel(model))
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