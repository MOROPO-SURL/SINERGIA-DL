using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Organization;

public class OrganizationDetailPageModel : AbstractDetailEntityPageModel<OrganizationDetailDtoModel>
{
    public OrganizationDetailPageModel(OrganizationDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        DetailPhoneNumberCommand = new Command<PhoneNumberDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new UI.Pages.Common.Detail.PhoneNumberDetailPage(model));
        });

        DetailEmailAddressCommand = new Command<EmailAddressDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new UI.Pages.Common.Detail.EmailAddressDetailPage(model));
        });

        DetailPostalAddressCommand = new Command<PostalAddressDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new UI.Pages.Common.Detail.PostalAddressDetailPage(model));
        });

        DetailWebSiteAddressCommand = new Command<WebSiteAddressDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new UI.Pages.Common.Detail.WebSiteAddressDetailPage(model));
        });
    }

    public ICommand DetailPhoneNumberCommand { get; private set; }

    public ICommand DetailEmailAddressCommand { get; private set; }

    public ICommand DetailPostalAddressCommand { get; private set; }

    public ICommand DetailWebSiteAddressCommand { get; private set; }

    protected override async Task PerformRemotionAsync(OrganizationDetailDtoModel model)
    {
        OrganizationCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        await apiClient.ArchiveAsync(model.Id);
    }
}