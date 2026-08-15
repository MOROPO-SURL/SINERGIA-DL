using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Shells;

public partial class AppShell : Shell
{
    public AppShell(Common.Models.Page.AppShellPageModel model)
    {
        InitializeComponent();

        BindingContext = model;

        DevelopmentActorProfileShellContent.ContentTemplate = model.Organization.Kind.DevelopmentActorProfileKind switch
        {
            GEDEL.CAMCMG.Interop.Contracts.Enumerations.DevelopmentActorProfileKind.NaturalPDL => new DataTemplate(() => new NaturalOwnedPDLDevelopmentActorProfileDetailPage()),
            GEDEL.CAMCMG.Interop.Contracts.Enumerations.DevelopmentActorProfileKind.LegalPDL => new DataTemplate(() => new LegalOwnedPDLDevelopmentActorProfileDetailPage()),
            _ => throw new InvalidOperationException(),
        };
    }

    private void BackHomeButton_Clicked(object sender, EventArgs eventArgs)
    {
        Application.Current!.MainPage = new NavigationPage(new Pages.MainPage());
    }

    private void ConfigurationMenuItem_Clicked(object sender, EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Terminal.Common.UI.Pages.SettingPage(SettingChange_Callback));
    }

    private void HelpMenuItem_Clicked(object sender, EventArgs eventArgs)
    {
        Launcher.OpenAsync(new Uri(Constants.InteropConstants.HELP_URL)).GetAwaiter().GetResult();
    }

    private void SettingChange_Callback()
    {
        IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>().Reset();

        Application.Current!.PresentToastNotification(Terminal.Common.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");
    }
}