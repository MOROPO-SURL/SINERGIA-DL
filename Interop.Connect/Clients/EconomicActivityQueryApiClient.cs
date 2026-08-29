using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.EconomicActivity.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;

public sealed class EconomicActivityQueryApiClient : Abstracts.AbstractQueryApiClient<int, EconomicActivityBasicDtoModel, EconomicActivityDetailDtoModel>
{
    public EconomicActivityQueryApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/economicactivities";
}