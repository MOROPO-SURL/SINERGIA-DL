using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages;

public partial class MainPage : 
    BaseListEntityPage<OrganizationBasicDtoModel, MainPageModel>,
    IListItemsPageModelPresenter<OrganizationBasicDtoModel>
{
    public MainPage() : base(new MainPageModel())
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);

        if (DeviceInfo.Current.Platform == DevicePlatform.Android) ItemsCollectionView.Header = BindingContext;
    }

    public Task PresentItemDetailUserInterfaceAsync(OrganizationBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        return Task.Run(async () =>
        {
            ISessionManagerPort sessionManager = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>();

            IHttpClientProviderPort httpClientProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

            OrganizationQueryApiClient organizationApiClient = new(httpClientProvider);
            NaturalOwnedPDLDevelopmentActorProfilesQueryApiClient naturalPDLClient = new(httpClientProvider);
            LegalOwnedPDLDevelopmentActorProfilesQueryApiClient legalPDLClient = new(httpClientProvider);

            Guid? developmentActorProfileId;

            OrganizationDetailDtoModel organization = await organizationApiClient.GetAsync(model.Id);

            try
            {
                developmentActorProfileId = (await naturalPDLClient.GetBasicByOwnerAsync(organization.Id)).Id;
            }
            catch (System.Text.Json.JsonException)
            {
                try
                {
                    developmentActorProfileId = (await legalPDLClient.GetBasicByOwnerAsync(organization.Id)).Id;
                }
                catch (System.Text.Json.JsonException)
                {
                    developmentActorProfileId = null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }

            PersonBasicDtoModel representative = organization.RepresentativePersons.First(item => item.UserId == sessionManager.CurrentSession!.User.Id);

            Common.Models.Page.AppShellPageModel pageModel = new(organization, representative, developmentActorProfileId);

            Dispatcher.Dispatch(() => Application.Current!.MainPage = new Shells.AppShell(pageModel));
        }).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = false;

                if (task.IsCompletedSuccessfully) return;

                IPlatformApplication.Current!.Services.GetRequiredService<Terminal.Common.Ports.Helper.IExceptionHandlingHelperPort>().HandleException(task.Exception);
            });
        });
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