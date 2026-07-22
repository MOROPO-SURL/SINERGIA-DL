using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages;

public partial class DevelopmentActorProfileDetailPage : BaseBindingContextedContentPage<Models.Page.DevelopmentActorProfileDetailPageModel>
{
	public DevelopmentActorProfileDetailPage() : base(new Models.Page.DevelopmentActorProfileDetailPageModel())
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ConcreteBindingContext.Initialize();
    }
}