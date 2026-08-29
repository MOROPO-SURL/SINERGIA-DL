using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PDLModality.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages;
using System.Text.Json;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page.DevelopmentActorProfile;

public sealed class NaturalOwnedPDLDevelopmentActorProfileDetailPageModel : BasePageModel
{
    private NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel? model;

    public NaturalOwnedPDLDevelopmentActorProfileDetailPageModel()
    {
        ModifyCommand = new Command(() =>
        {
            if (model == null) return;

            IsBusy = true;

            PDLModalitiesQueryApiClient modalitiesQueryApiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

            modalitiesQueryApiClient.GetPageAsync(1, 1000).ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    IsBusy = false;

                    if (task.IsCompletedSuccessfully)
                    {
                        Application.Current!.MainPage!.NavigationPushPageAsync(new NaturalOwnedPDLDevelopmentActorProfileConfigurationPage(new NaturalOwnedPDLDevelopmentActorProfileConfigurationPageModel(model!, task.Result.Items, ConfigurationSuccess_Callback, new Validators.NaturalOwnedPDLDevelopmentActorProfileConfigurationValidator())));

                        return;
                    }

                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                });
            });
        });

        DetailLocationCommand = new Command<LocationDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new LocationDetailPage(model));
        });
    }

    public NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel? Model { get => model; set => SetProperty(ref model, value); }

    public ICommand ModifyCommand { get; set; }

    public ICommand DetailLocationCommand { get; init; }

    public void Initialize()
    {
        IsBusy = true;

        IHttpClientProviderPort httpClientHelperProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

        NaturalOwnedPDLDevelopmentActorProfilesQueryApiClient actorProfilesQueryApiClient = new(httpClientHelperProvider);
        PDLModalitiesQueryApiClient modalitiesQueryApiClient = new(httpClientHelperProvider);

        Task<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel> getDetailByOwnerTask = actorProfilesQueryApiClient.GetDetailByOwnerAsync(((Common.Models.Page.AppShellPageModel)Shell.Current!.BindingContext).Organization.Id);
        Task<PaginateResultModel<PDLModalityBasicDtoModel>> avalableModalitiesTask = modalitiesQueryApiClient.GetPageAsync(1, 1000);

        Task.WhenAll(getDetailByOwnerTask, avalableModalitiesTask).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                IsBusy = false;

                if (task.IsCompletedSuccessfully)
                {
                    Model = getDetailByOwnerTask.Result;

                    return;
                }

                if (task.Exception != null && task.Exception.InnerException is JsonException)
                {
                    Application.Current!.MainPage!.NavigationPushPageAsync(new NaturalOwnedPDLDevelopmentActorProfileConfigurationPage(new NaturalOwnedPDLDevelopmentActorProfileConfigurationPageModel(null, avalableModalitiesTask.Result.Items, ConfigurationSuccess_Callback, new Validators.NaturalOwnedPDLDevelopmentActorProfileConfigurationValidator()))).ContinueWith(_ =>
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

    private void ConfigurationSuccess_Callback(NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel model)
    {
        Model = model;

        Application.Current!.PresentToastNotification(Terminal.Common.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");
    }
}
