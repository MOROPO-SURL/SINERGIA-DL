using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page;

public sealed class MainPageModel : AbstractListEntityPageModel<OrganizationBasicDtoModel>
{
    protected override async Task<PaginateResultModel<OrganizationBasicDtoModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        ISessionManagerPort sessionManager = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>();

        OrganizationQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        Task<OrganizationBasicDtoModel[]> listLegalPDLTask = apiClient.GetByDevelopmentActorProfileKindAndUserAsync(GEDEL.CAMCMG.Interop.Contracts.Enumerations.DevelopmentActorProfileKind.LegalPDL, sessionManager.CurrentSession!.User.Id);
        Task<OrganizationBasicDtoModel[]> listNaturalPDLTask = apiClient.GetByDevelopmentActorProfileKindAndUserAsync(GEDEL.CAMCMG.Interop.Contracts.Enumerations.DevelopmentActorProfileKind.NaturalPDL, sessionManager.CurrentSession!.User.Id);

        await Task.WhenAll(listLegalPDLTask, listNaturalPDLTask);

        int itemCount = listLegalPDLTask.Result.Length + listNaturalPDLTask.Result.Length;

        if (itemCount < 1) throw new InvalidDataException();

        return new PaginateResultModel<OrganizationBasicDtoModel>
        {
            Page = 1,
            Limit = itemCount,
            HasNext = false,
            HasPrevious = false,
            MaxPageCount = 1,
            Items = [.. listLegalPDLTask.Result.Concat(listNaturalPDLTask.Result)]
        };
    }

    protected override void HandleException(Exception? exception)
    {
        if (exception != null && exception.InnerException is InvalidDataException) 
        {
            Application.Current!.MainPage!.DisplayAlert("Aviso", $"Su usuario no representa a ninguna entidad identificada como actor de desarrollo, específicamente Proyectos de Desarrollo Local (PDL).{Environment.NewLine}{Environment.NewLine}Esta condición es de carácter obligatorio para el uso de esta aplicación, por lo que su sesión será finalizada.", "Aceptar")
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
