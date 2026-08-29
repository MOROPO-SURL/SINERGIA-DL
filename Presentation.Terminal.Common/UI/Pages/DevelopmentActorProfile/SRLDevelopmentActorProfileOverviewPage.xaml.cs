using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.DevelopmentActorProfile;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.DevelopmentActorProfile;

public partial class SRLDevelopmentActorProfileOverviewPage : BaseDetailEntityPage<SRLDevelopmentActorProfileDetailDtoModel, SRLDevelopmentActorProfileOverviewDetailPageModel>
{
	public SRLDevelopmentActorProfileOverviewPage(SRLDevelopmentActorProfileOverviewDetailPageModel model) : base(model)
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