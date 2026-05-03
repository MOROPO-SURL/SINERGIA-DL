using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;

public sealed class MacroprogramQueryApiClient : AbstractQueryApiClient<Guid, MacroprogramBasicDtoModel, MacroprogramDetailDtoModel>
{
    public MacroprogramQueryApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/macroprograms";
}