using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritoryPotential.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritoryPotential.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;

public sealed class TerritoryPotentialCommandApiClient : AbstractArchivableCommandApiClient<Guid, TerritoryPotentialCreateRequestModel, TerritoryPotentialUpdateRequestModel, TerritoryPotentialDetailDtoModel>
{
    public TerritoryPotentialCommandApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/territorypotentials";
}