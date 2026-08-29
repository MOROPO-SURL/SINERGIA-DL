using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;

public sealed class ObjectiveQueryApiClient : AbstractQueryApiClient<Guid, ObjectiveBasicDtoModel, ObjectiveDetailDtoModel>
{
    public ObjectiveQueryApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/objectives";
}