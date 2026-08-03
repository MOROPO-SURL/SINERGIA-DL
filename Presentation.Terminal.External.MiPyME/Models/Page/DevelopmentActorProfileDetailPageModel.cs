using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.UI.Pages;
using System.Text.Json;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page;

public sealed class DevelopmentActorProfileDetailPageModel : BasePageModel
{
    private SRLDevelopmentActorProfileDetailDtoModel? model;

    public DevelopmentActorProfileDetailPageModel()
    {
        ModifyCommand = new Command(() =>
        {
            if (model == null) return;

            Application.Current!.MainPage!.NavigationPushPageAsync(new DevelopmentActorProfileConfigurationPage(new DevelopmentActorProfileConfigurationPageModel(model!, ConfigurationSuccess_Callback, new Validators.DevelopmentActorProfileConfigurationValidator())));
        });

        DetailLocationCommand = new Command<LocationDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new LocationDetailPage(model));
        });
    }

    public SRLDevelopmentActorProfileDetailDtoModel? Model { get => model; set => SetProperty(ref model, value); }

    public ICommand ModifyCommand { get; init; }

    public ICommand DetailLocationCommand { get; init; }

    public void Initialize()
    {
        IsBusy = true;

        IHttpClientProviderPort httpClientHelperProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

        SRLDevelopmentActorProfilesQueryApiClient actorProfilesQueryApiClient = new(httpClientHelperProvider);

        actorProfilesQueryApiClient.GetDetailByOwnerAsync(((Common.Models.Page.AppShellPageModel)Shell.Current!.BindingContext).Organization.Id).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                IsBusy = false;

                if (task.IsCompletedSuccessfully)
                {
                    Model = task.Result;

                    return;
                }

                if (task.Exception != null && task.Exception.InnerException is JsonException)
                {
                    Application.Current!.MainPage!.NavigationPushPageAsync(new DevelopmentActorProfileConfigurationPage(new DevelopmentActorProfileConfigurationPageModel(null, ConfigurationSuccess_Callback, new Validators.DevelopmentActorProfileConfigurationValidator()))).ContinueWith(_ =>
                    {
                        Dispatcher.Dispatch(() => Application.Current!.PresentToastNotification(Terminal.Common.Enumerations.NotificationKind.Warning, "Es necesario completar el perfil de actor del desarrollo."));
                    });

                    return;
                }
                else
                {
                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                }
            });
        });
    }

    private void ConfigurationSuccess_Callback(SRLDevelopmentActorProfileDetailDtoModel model)
    {
        Model = model;

        ((Common.Models.Page.AppShellPageModel)((UI.Shells.AppShell)Application.Current!.MainPage!).BindingContext).DevelopmentProfileId = model.Id;

        Application.Current!.PresentToastNotification(Terminal.Common.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");
    }
}
