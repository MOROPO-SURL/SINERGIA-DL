using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialResponsabilityAction.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;

public sealed class PDLSocialResponsabilityActionCommandApiClient : AbstractArchivableCommandApiClient<Guid, PDLSocialResponsabilityActionCreateRequestModel, PDLSocialResponsabilityActionUpdateRequestModel, PDLSocialResponsabilityActionDetailDtoModel>
{
    public PDLSocialResponsabilityActionCommandApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/pdlsocialresponsabilityactions";
}