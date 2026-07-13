using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Shells;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
    }

    private void ConfigurationMenuItem_Clicked(object sender, EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new SettingPage(SettingChange_Callback));
    }

    private void HelpMenuItem_Clicked(object sender, EventArgs eventArgs)
    {
        Launcher.OpenAsync(new Uri(Constants.InteropConstants.HELP_URL)).GetAwaiter().GetResult();
    }

    private void UserProfileMenuItem_Clicked(object sender, EventArgs eventArgs)
    {
        Launcher.OpenAsync(new Uri(Common.Constants.InteropConstants.USER_PROFILE_URL)).GetAwaiter().GetResult();
    }

    private void LogOutMenuItem_Clicked(object sender, EventArgs eventArgs)
    {
        ISessionManagerPort sessionManager = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>();

        if (sessionManager.CurrentSession?.User == null) return;

        DisplayAlert("Confirmación", "Está seguro que desea terminar su sesión?", "Confirmar", "Cancelar").ContinueWith(async task =>
        {
            if (!task.Result) return;

            await sessionManager.SignOutAsync();

            Dispatcher.Dispatch(() => this.NavigationPushModalPageAsync(new Pages.UserAuthenticationPage()));
        });
    }

    private void SettingChange_Callback()
    {
        IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>().Reset();

        Application.Current!.PresentToastNotification(Common.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");
    }
}