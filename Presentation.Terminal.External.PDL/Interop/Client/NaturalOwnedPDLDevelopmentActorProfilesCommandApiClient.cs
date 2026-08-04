using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Interop.Connect.Client;

public sealed class NaturalOwnedPDLDevelopmentActorProfilesCommandApiClient : AbstractCommandApiClient<Guid, NaturalOwnedPDLDevelopmentActorProfileCreateRequestModel, NaturalOwnedPDLDevelopmentActorProfileUpdateRequestModel, NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel>
{
    public NaturalOwnedPDLDevelopmentActorProfilesCommandApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/naturalownedpdldevelopmentactorprofiles";
}