using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Manager;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class MainPage : BaseBindingContextedContentPage<MainPageModel>
{
    public MainPage() : base(new MainPageModel())
    {
        InitializeComponent();

        IsEnabled = false;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ISessionManagerPort sessionManager = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>();

        if (sessionManager.CurrentSession?.User == null)
        {
            this.NavigationPushModalPageAsync(new UserAuthenticationPage());

            return;
        }

        if (IsEnabled) return;

        IsEnabled = true;

        ReloadToolbarItem_Clicked(this, EventArgs.Empty);
    }

    private void ReloadToolbarItem_Clicked(object sender, EventArgs eventArgs)
    {
        ConcreteBindingContext.PerformEnvironmentReadyCheck();
    }

    private async void GoComplementSecctionButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(new ShellNavigationState($"///{typeof(EnvironmentSummaryPage).Name}"));
    }
}
