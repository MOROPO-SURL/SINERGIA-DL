using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.UI.Pages;

public partial class DevelopmentActorProfileDetailPage : BaseBindingContextedContentPage<Models.Page.DevelopmentActorProfile.DevelopmentActorProfileDetailPageModel>
{
	public DevelopmentActorProfileDetailPage() : base(new Models.Page.DevelopmentActorProfile.DevelopmentActorProfileDetailPageModel())
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ConcreteBindingContext.Initialize();
    }
}