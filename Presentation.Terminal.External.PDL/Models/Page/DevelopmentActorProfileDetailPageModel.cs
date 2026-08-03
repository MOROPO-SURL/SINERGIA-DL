using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages;
using System.Text.Json;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page;

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
    }

    public SRLDevelopmentActorProfileDetailDtoModel? Model { get => model; set => SetProperty(ref model, value); }

    public ICommand ModifyCommand { get; set; }

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

        Application.Current!.PresentToastNotification(Terminal.Common.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");
    }
}
