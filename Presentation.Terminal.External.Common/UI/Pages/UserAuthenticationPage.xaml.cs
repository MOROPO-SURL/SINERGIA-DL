using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.UI.Pages;

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

        Application.Current!.PresentToastNotification(Terminal.Common.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");
    }
}
