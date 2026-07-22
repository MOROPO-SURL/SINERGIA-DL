using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.External.Common.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page;

public sealed class DashboardPageModel : AbstractContextPageModel
{
    private bool isDevelopmentActorProfileMissing;

    public DashboardPageModel(OrganizationDetailDtoModel organization, PersonBasicDtoModel representative) : base(organization, representative)
    {
    }

    public bool IsDevelopmentActorProfileMissing { get => isDevelopmentActorProfileMissing; set => SetProperty(ref isDevelopmentActorProfileMissing, value); }

    public void LoadState()
    {
        IsBusy = true;

        IHttpClientProviderPort httpClientHelperProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

        SRLDevelopmentActorProfilesQueryApiClient actorProfilesQueryApiClient = new(httpClientHelperProvider);

        Task<SRLDevelopmentActorProfileBasicDtoModel> developmentActorProfileByOwnerTask = actorProfilesQueryApiClient.GetBasicByOwnerAsync(((Common.Models.Page.AppShellPageModel)Shell.Current!.BindingContext).Organization.Id);

        developmentActorProfileByOwnerTask.ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                IsDevelopmentActorProfileMissing = !developmentActorProfileByOwnerTask.IsCompletedSuccessfully;
                IsBusy = false;
            });
        });
    }
}