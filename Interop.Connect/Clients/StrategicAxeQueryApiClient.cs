using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;

public sealed class StrategicAxeQueryApiClient : AbstractQueryApiClient<int, StrategicAxeBasicDtoModel, StrategicAxeDetailDtoModel>
{
    public StrategicAxeQueryApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/strategicaxes";
}