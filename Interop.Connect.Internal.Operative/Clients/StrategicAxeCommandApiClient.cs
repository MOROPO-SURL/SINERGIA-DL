using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;

public sealed class StrategicAxeCommandApiClient : AbstractArchivableCommandApiClient<int, StrategicAxeCreateRequestModel, StrategicAxeUpdateRequestModel, StrategicAxeDetailDtoModel>
{
    public StrategicAxeCommandApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/strategicaxes";
}