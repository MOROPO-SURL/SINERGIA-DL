using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.External.Common.Clients;

public sealed class SRLDevelopmentActorProfilesCommandApiClient : AbstractCommandApiClient<Guid, SRLDevelopmentActorProfileCreateRequestModel, SRLDevelopmentActorProfileUpdateRequestModel, SRLDevelopmentActorProfileDetailDtoModel>
{
    public SRLDevelopmentActorProfilesCommandApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/srldevelopmentactorprofiles";
}
