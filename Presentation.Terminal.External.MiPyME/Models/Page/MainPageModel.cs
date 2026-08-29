using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Enumerations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page;

public sealed class MainPageModel : AbstractListEntityPageModel<OrganizationBasicDtoModel>
{
    protected override async Task<PaginateResultModel<OrganizationBasicDtoModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        ISessionManagerPort sessionManager = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>();

        OrganizationQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        Task<OrganizationBasicDtoModel[]> listTask = apiClient.GetByDevelopmentActorProfileKindAndUserAsync(DevelopmentActorProfileKind.SRL, sessionManager.CurrentSession!.User.Id);

        await listTask;

        if (listTask.Result.Length < 1) throw new InvalidDataException();

        return new PaginateResultModel<OrganizationBasicDtoModel>
        {
            Page = 1,
            Limit = listTask.Result.Length,
            HasNext = false,
            HasPrevious = false,
            MaxPageCount = 1,
            Items = [.. listTask.Result]
        };
    }

    protected override void HandleException(Exception? exception)
    {
        if (exception != null && exception.InnerException is InvalidDataException)
        {
            Application.Current!.MainPage!.DisplayAlert("Aviso", $"Su usuario no representa a ninguna entidad identificada como actor de desarrollo, específicamente Sociedades mercantiles de Responsabilidad Limitada (SRL / SURL / MiPyMEs).{Environment.NewLine}{Environment.NewLine}Esta condición es de carácter obligatorio para el uso de esta aplicación, por lo que su sesión será finalizada.", "Aceptar")
                .ContinueWith(async _ =>
                {
                    ISessionManagerPort sessionManager = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>();

                    await sessionManager.SignOutAsync();

                    Dispatcher.Dispatch(() =>
                    {
                        IsEnabled = false;
                        IsBusy = true;

                        Application.Current!.MainPage!.NavigationPushModalPageAsync(new UI.Pages.UserAuthenticationPage());
                    });
                });

            return;
        }

        base.HandleException(exception);
    }
}
