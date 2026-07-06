using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.UI.Pages;

public partial class MainPage : 
    BaseListEntityPage<OrganizationBasicDtoModel, MainPageModel>,
    IListItemsPageModelPresenter<OrganizationBasicDtoModel>
{
    public MainPage() : base(new MainPageModel())
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemDetailUserInterfaceAsync(OrganizationBasicDtoModel model)
    {
        await DisplayAlert("Aviso", "Funcionalidad en construcción. Espere nuevas versiones de la aplicación.", "Aceptar");
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ISessionManagerPort sessionManager = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>();

        if (sessionManager.CurrentSession?.User == null)
        {
            ConcreteBindingContext.IsEnabled = false;
            ConcreteBindingContext.IsBusy = true;

            this.NavigationPushModalPageAsync(new UserAuthenticationPage());

            return;
        }

        if (ConcreteBindingContext.IsBusy && !ConcreteBindingContext.IsEnabled)
        {
            ConcreteBindingContext.IsEnabled = true;

            ConcreteBindingContext.LoadItems(true);
        }
    }

    private void DiagnosticSummaryFrameTapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        this.NavigationPushPageAsync(new DiagnosticSummaryPage());
    }

    private void EDLSummaryFrameTapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        this.NavigationPushPageAsync(new StrategySummaryPage());
    }

    private void ConfigurationToolbarItem_Clicked(object sender, EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new SettingPage(SettingChange_Callback));
    }

    private void HelpToolbarItem_Clicked(object sender, EventArgs eventArgs)
    {
        Launcher.OpenAsync(new Uri(Constants.InteropConstants.HELP_URL)).GetAwaiter().GetResult();
    }

    private void UserProfileToolbarItem_Clicked(object sender, EventArgs eventArgs)
    {
        Launcher.OpenAsync(new Uri(Terminal.Common.Constants.InteropConstants.USER_PROFILE_URL)).GetAwaiter().GetResult();
    }

    private void LogOutToolbarItem_Clicked(object sender, EventArgs eventArgs)
    {
        ISessionManagerPort sessionManager = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>();

        if (sessionManager.CurrentSession?.User == null) return;

        DisplayAlert("Confirmación", "Está seguro que desea terminar su sesión?", "Confirmar", "Cancelar").ContinueWith(async task =>
        {
            if (!task.Result) return;

            await sessionManager.SignOutAsync();

            Dispatcher.Dispatch(() => this.NavigationPushModalPageAsync(new UserAuthenticationPage()));
        });
    }

    private void SettingChange_Callback()
    {
        IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>().Reset();

        Application.Current!.PresentToastNotification(Terminal.Common.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");
    }
}