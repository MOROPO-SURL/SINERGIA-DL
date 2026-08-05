using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;

public sealed class PDLSocialResponsabilityActionCommandApiClient : AbstractArchivableCommandApiClient<Guid, PDLSocialResponsabilityActionCreateRequestModel, PDLSocialResponsabilityActionUpdateRequestModel, PDLSocialResponsabilityActionDetailDtoModel>
{
    public PDLSocialResponsabilityActionCommandApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/pdlsocialresponsabilityactions";
}