using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Manager;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var sessionManager = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>();

        //BindingContextPageModel.User = sessionManager.CurrentSession?.User;

        if (sessionManager.CurrentSession?.User == null)
        {
            this.NavigationPushModalPageAsync(new UserAuthenticationPage());
        }
    }
}
