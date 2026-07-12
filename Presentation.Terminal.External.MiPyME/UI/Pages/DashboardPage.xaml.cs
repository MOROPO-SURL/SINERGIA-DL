using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.UI.Pages;

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

    private void DiagnosticSummaryFrameTapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        this.NavigationPushPageAsync(new DiagnosticSummaryPage());
    }

    private void EDLSummaryFrameTapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        this.NavigationPushPageAsync(new StrategySummaryPage());
    }

    private async void GoDevelopmentActorProfileSecctionButton_Clicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync(new ShellNavigationState("///DevelopmentActorProfile"));
    }
}