using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;

public sealed class StrategicLineCommandApiClient
{
    private const string USE_CASE_BASE_URI_SEGMENT = "api/strategiclines";

    private readonly IHttpClientProviderPort httpClientProvider;

    public StrategicLineCommandApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<StrategicLineDetailDtoModel> CreateAsync(StrategicLineCreateRequestModel model)
    {
        return httpClientProvider.GetHttpClient().SendPostAsync<StrategicLineCreateRequestModel, StrategicLineDetailDtoModel>(USE_CASE_BASE_URI_SEGMENT, model);
    }

    public Task<StrategicLineDetailDtoModel> UpdateAsync(StrategicLineUpdateRequestModel model)
    {
        return httpClientProvider.GetHttpClient().SendPutAsync<StrategicLineUpdateRequestModel, StrategicLineDetailDtoModel>(USE_CASE_BASE_URI_SEGMENT, model);
    }

    public Task DeleteAsync(int id, int axeId)
    {
        return httpClientProvider.GetHttpClient().SendDeleteAsync($"{USE_CASE_BASE_URI_SEGMENT}/{id}/axe/{axeId}");
    }

    public Task ArchiveAsync(int id, int axeId)
    {
        return httpClientProvider.GetHttpClient().SendPatchAsync($"{USE_CASE_BASE_URI_SEGMENT}/{id}/axe/{axeId}/archive");
    }
}