using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page;

public sealed class MainPageModel : BasePageModel
{
    private bool isEnvironmentNotReady;

    public bool IsEnvironmentNotReady { get => isEnvironmentNotReady; set => SetProperty(ref isEnvironmentNotReady, value); }

    public void PerformEnvironmentReadyCheck()
    {
        IHttpClientProviderPort httpClientHelperProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

        FeatureKindQueryApiClient featureKindQueryApiClient = new(httpClientHelperProvider);
        OrganizationKindQueryApiClient organizationKindQueryApiClient = new(httpClientHelperProvider);
        StrategicProjectKindQueryApiClient projectKindQueryApiClient = new(httpClientHelperProvider);
        UnitMeasurementQueryApiClient unitMeasurementQueryApiClient = new(httpClientHelperProvider);

        Task<int> featureKindCountTask = featureKindQueryApiClient.CountAsync();
        Task<int> organizationKindCountTask = organizationKindQueryApiClient.CountAsync();
        Task<int> projectKindCountTask = projectKindQueryApiClient.CountAsync();
        Task<int> unitMeasurementCountTask = unitMeasurementQueryApiClient.CountAsync();

        IsBusy = true;

        Task.WhenAll(featureKindCountTask, organizationKindCountTask, projectKindCountTask, unitMeasurementCountTask).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                IsBusy = false;

                if (task.IsCompletedSuccessfully)
                {
                    bool hasAnyFeatureKind = featureKindCountTask.Result > 0;
                    bool hasAnyOrganizationKind = organizationKindCountTask.Result > 0;
                    bool hasAnyProjectKind = organizationKindCountTask.Result > 0;
                    bool hasAnyUnitMeasurement = unitMeasurementCountTask.Result > 0;

                    IsEnvironmentNotReady =
                        !hasAnyFeatureKind ||
                        !hasAnyOrganizationKind ||
                        !hasAnyProjectKind ||
                        !hasAnyUnitMeasurement;
                }
                else
                {
                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                }
            });
        });
    }
}
