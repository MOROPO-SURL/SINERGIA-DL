using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;

public sealed class OrganizationQueryApiClient : AbstractQueryApiClient<Guid, OrganizationBasicDtoModel, OrganizationDetailDtoModel>
{
    public OrganizationQueryApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/organizations";
}
