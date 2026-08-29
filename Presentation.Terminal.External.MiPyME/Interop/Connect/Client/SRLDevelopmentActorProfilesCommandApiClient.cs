using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Interop.Connect.Client;

public sealed class SRLDevelopmentActorProfilesCommandApiClient : AbstractCommandApiClient<Guid, SRLDevelopmentActorProfileCreateRequestModel, SRLDevelopmentActorProfileUpdateRequestModel, SRLDevelopmentActorProfileDetailDtoModel>
{
    public SRLDevelopmentActorProfilesCommandApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/srldevelopmentactorprofiles";
}