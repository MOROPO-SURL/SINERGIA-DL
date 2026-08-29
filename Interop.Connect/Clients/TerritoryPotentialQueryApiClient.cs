using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritoryPotential.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;

public sealed class TerritoryPotentialQueryApiClient : AbstractQueryApiClient<Guid, TerritoryPotentialBasicDtoModel, TerritoryPotentialDetailDtoModel>
{
    public TerritoryPotentialQueryApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/territorypotentials";
}