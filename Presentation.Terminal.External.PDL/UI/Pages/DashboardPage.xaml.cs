using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();

		IsEnabled = false;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		if (!IsEnabled)
		{
			AppShellPageModel parentBindingContext = (AppShellPageModel)Parent.BindingContext;

            BindingContext = new DashboardPageModel(parentBindingContext.Organization, parentBindingContext.Representative);
		}

		IsEnabled = true;
    }
}