using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class UserAuthenticationPage : BaseBindingContextedContentPage<UserAuthenticationPageModel>
{
	public UserAuthenticationPage() : base(new UserAuthenticationPageModel())
    {
		InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        DisplayAlert("Aviso", "Está seguro que desea salir de la aplicación?", "Salir", "Cancelar").ContinueWith(task =>
        {
            if (task.Result)
            {
                Dispatcher.Dispatch(Application.Current!.Quit);
            }
        });

        return true;
    }

    private void SettingButton_Clicked(object sender, EventArgs e)
    {
        this.NavigationPushModalPageAsync(new SettingPage(SettingChange_Callback));
    }

    private void SettingChange_Callback()
    {
        IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>().Reset();

        this.PresentToastNotification(Terminal.Common.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");
    }
}
