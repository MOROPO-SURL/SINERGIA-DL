using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;

public sealed class OrganizationQueryApiClient : AbstractQueryApiClient<Guid, OrganizationBasicDtoModel, OrganizationDetailDtoModel>
{
    public OrganizationQueryApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/organizations";

    public Task<OrganizationBasicDtoModel[]> GetByDevelopmentActorProfileKindAndUserAsync(Contracts.Enumerations.DevelopmentActorProfileKind developmentActorProfileKind, string userId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<OrganizationBasicDtoModel[]>($"{GetUseCaseBaseUriSegment()}/list/developmentprofilable/{developmentActorProfileKind}/user/{userId}");
    }
}
