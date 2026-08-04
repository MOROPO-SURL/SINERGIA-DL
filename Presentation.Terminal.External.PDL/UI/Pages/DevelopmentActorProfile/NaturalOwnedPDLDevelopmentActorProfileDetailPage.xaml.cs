using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages;

public partial class NaturalOwnedPDLDevelopmentActorProfileDetailPage : BaseBindingContextedContentPage<Models.Page.DevelopmentActorProfile.NaturalOwnedPDLDevelopmentActorProfileDetailPageModel>
{
	public NaturalOwnedPDLDevelopmentActorProfileDetailPage() : base(new Models.Page.DevelopmentActorProfile.NaturalOwnedPDLDevelopmentActorProfileDetailPageModel())
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ConcreteBindingContext.Initialize();
    }
}