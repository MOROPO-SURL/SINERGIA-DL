using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class EnvironmentSummaryPage : BaseBindingContextedContentPage<Models.Page.EnvironmentSummaryPageModel>
{
	public EnvironmentSummaryPage() : base(new Models.Page.EnvironmentSummaryPageModel())
	{
		InitializeComponent();

        IsEnabled = false;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (IsEnabled) return;

        IsEnabled = true;

        ReloadToolbarItem_Clicked(this, EventArgs.Empty);
    }

    private void ReloadToolbarItem_Clicked(object sender, EventArgs eventArgs)
    {
        ConcreteBindingContext.LoadSummary();
    }

    private async void UnitMeasurementManageButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(new ShellNavigationState($"///{typeof(UnitMeasurementsManagementPage).Name}"));
    }

    private async void StrategicProjectKindAdminButton_Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync($"{Constants.InteropConstants.ADMINISTRATION_BASE_URL}/complement/strategicprojectkinds");
    }

    private async void OrganizationKindAdminButton_Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync($"{Constants.InteropConstants.ADMINISTRATION_BASE_URL}/complement/organizationkinds");
    }

    private async void FeatureKindAdminButton_Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync($"{Constants.InteropConstants.ADMINISTRATION_BASE_URL}/complement/featurekinds");
    }
}