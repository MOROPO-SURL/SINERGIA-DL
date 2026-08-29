using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;

public sealed class StrategicLineQueryApiClient : AbstractQueryApiClient<Guid, StrategicLineBasicDtoModel, StrategicLineDetailDtoModel>
{
    public StrategicLineQueryApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/strategiclines";
}