using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page;

public sealed class MainPageModel : BasePageModel
{
    private bool isEnvironmentReady;
    private bool hasAnyFeatureKind;
    private bool hasAnyOrganizationKind;
    private bool hasAnyProjectKind;
    private bool hasAnyUnitMeasurement;

    public bool IsEnvironmentReady { get => isEnvironmentReady; set => SetProperty(ref isEnvironmentReady, value); }

    public bool HasAnyFeatureKind { get => hasAnyFeatureKind; set => SetProperty(ref hasAnyFeatureKind, value); }

    public bool HasAnyOrganizationKind { get => hasAnyOrganizationKind; set => SetProperty(ref hasAnyOrganizationKind, value); }

    public bool HasAnyProjectKind { get => hasAnyProjectKind; set => SetProperty(ref hasAnyProjectKind, value); }

    public bool HasAnyUnitMeasurement { get => hasAnyUnitMeasurement; set => SetProperty(ref hasAnyUnitMeasurement, value); }

    public void LoadSummary()
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
                    HasAnyFeatureKind = featureKindCountTask.Result > 0;
                    HasAnyOrganizationKind = organizationKindCountTask.Result > 0;
                    HasAnyProjectKind = projectKindCountTask.Result > 0;
                    HasAnyUnitMeasurement = unitMeasurementCountTask.Result > 0;

                    IsEnvironmentReady =
                        hasAnyFeatureKind &&
                        hasAnyOrganizationKind &&
                        hasAnyProjectKind &&
                        hasAnyUnitMeasurement;
                }
                else
                {
                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                }
            });
        });
    }
}
