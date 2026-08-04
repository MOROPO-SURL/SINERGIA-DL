using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages;

public partial class LegalOwnedPDLDevelopmentActorProfileDetailPage : BaseBindingContextedContentPage<Models.Page.DevelopmentActorProfile.LegalOwnedPDLDevelopmentActorProfileDetailPageModel>
{
	public LegalOwnedPDLDevelopmentActorProfileDetailPage() : base(new Models.Page.DevelopmentActorProfile.LegalOwnedPDLDevelopmentActorProfileDetailPageModel())
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ConcreteBindingContext.Initialize();
    }
}