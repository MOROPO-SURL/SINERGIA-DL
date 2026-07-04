using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.EconomicActivity.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;

public sealed class EconomicActivityQueryApiClient : Abstracts.AbstractQueryApiClient<int, EconomicActivityBasicDtoModel, EconomicActivityDetailDtoModel>
{
    public EconomicActivityQueryApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/economicactivities";
}