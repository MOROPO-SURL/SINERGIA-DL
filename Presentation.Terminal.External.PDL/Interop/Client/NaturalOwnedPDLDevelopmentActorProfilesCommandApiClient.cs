using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Interop.Connect.Client;

public sealed class NaturalOwnedPDLDevelopmentActorProfilesCommandApiClient : AbstractCommandApiClient<Guid, NaturalOwnedPDLDevelopmentActorProfileCreateRequestModel, NaturalOwnedPDLDevelopmentActorProfileUpdateRequestModel, NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel>
{
    public NaturalOwnedPDLDevelopmentActorProfilesCommandApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/naturalownedpdldevelopmentactorprofiles";
}