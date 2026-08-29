using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Location.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Validators;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Location;

public sealed class LocationPickPageModel : AbstractPickEntityPageModel<LocationDetailDtoModel>
{
    private readonly Action<LocationUpdateRequestModel> createRequiredCallbackAction;

    public LocationPickPageModel(Action<LocationDetailDtoModel> pickedCallbackAction, Action<LocationUpdateRequestModel> createRequiredCallbackAction) : base(pickedCallbackAction)
    {
        this.createRequiredCallbackAction = createRequiredCallbackAction;

        CreateCommand = new Command(() =>
        {
            if (Items.Count > 0 && string.IsNullOrEmpty(SearchParameter))
            {
                Application.Current!.MainPage!.DisplayAlert("Aviso", "Realice una búsqueda de la localizaciones deseada antes de agregarla al sistema, puede que ya exista.", "Aceptar");

                return;
            }

            Application.Current!.MainPage!.NavigationPushPageAsync(new LocationConfigurationPage(new LocationConfigurationPageModel(null, ConfigurationSuccess_Callback, new LocationConfigurationValidator())));
        });
    }

    protected override Task<PaginateResultModel<LocationDetailDtoModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        LocationQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        if (!string.IsNullOrEmpty(SearchParameter) && !string.IsNullOrWhiteSpace(SearchParameter))
        {
            return apiClient.FilterPageAsync(currentItemsPageNumber, currentItemsPageLimit, SearchParameter);
        }

        return apiClient.GetPageAsync(currentItemsPageNumber, currentItemsPageLimit);
    }

    public ICommand CreateCommand { get; private set; }

    private void ConfigurationSuccess_Callback(LocationUpdateRequestModel model)
    {
        Dispatcher.Dispatch(() =>
        {
            createRequiredCallbackAction.Invoke(model);

            Application.Current!.MainPage!.NavigationPopPageAsync();
        });
    }
}
