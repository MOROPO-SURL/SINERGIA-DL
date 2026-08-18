using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PersonTrace.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Common.Detail;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Person;

public sealed class PersonDetailPageModel : AbstractDetailEntityPageModel<PersonDetailDtoModel>
{
    private PersonTraceDetailDtoModel[]? traces;

    public PersonDetailPageModel(PersonDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        FetchTraceCommand = new Command(() =>
        {
            IsBusy = true;

            PersonTraceQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

            apiClient.GetForTargetAsync(Model.Id).ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    if (!task.IsCompletedSuccessfully)
                    {
                        IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                    }
                    else
                    {
                        Traces = task.Result;
                    }

                    IsBusy = false;
                });
            });
        });

        DetailPhoneNumberCommand = new Command<PhoneNumberDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new PhoneNumberDetailPage(model));
        });

        DetailEmailAddressCommand = new Command<EmailAddressDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new EmailAddressDetailPage(model));
        });

        DetailPostalAddressCommand = new Command<PostalAddressDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new PostalAddressDetailPage(model));
        });

        DetailWebSiteAddressCommand = new Command<WebSiteAddressDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new WebSiteAddressDetailPage(model));
        });
    }

    public PersonTraceDetailDtoModel[]? Traces { get => traces; private set => SetProperty(ref traces, value); }

    public ICommand FetchTraceCommand { get; init; }

    public ICommand DetailPhoneNumberCommand { get; private set; }

    public ICommand DetailEmailAddressCommand { get; private set; }

    public ICommand DetailPostalAddressCommand { get; private set; }

    public ICommand DetailWebSiteAddressCommand { get; private set; }

    protected override async Task PerformRemotionAsync(PersonDetailDtoModel model)
    {
        PersonCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        await apiClient.ArchiveAsync(model.Id);
    }
}
