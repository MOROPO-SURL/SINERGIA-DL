using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialResponsabilityAction.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;

public sealed class SRLSocialResponsabilityActionCommandApiClient : AbstractArchivableCommandApiClient<Guid, SRLSocialResponsabilityActionCreateRequestModel, SRLSocialResponsabilityActionUpdateRequestModel, SRLSocialResponsabilityActionDetailDtoModel>
{
    public SRLSocialResponsabilityActionCommandApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/srlsocialresponsabilityactions";
}
