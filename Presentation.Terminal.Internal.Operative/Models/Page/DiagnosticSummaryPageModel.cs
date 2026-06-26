using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Enumerations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Feature.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritorialBarrier.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritoryPotential.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using System.Collections.ObjectModel;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page;

public sealed class DiagnosticSummaryPageModel : BasePageModel
{
    private DateTime loadedAt;

    public DateTime LoadedAt { get => loadedAt; set => SetProperty(ref loadedAt, value); }

    public ObservableCollection<FeatureDetailDtoModel> Features { get; set; } = [];

    public ObservableCollection<ObjectiveDetailDtoModel> Objectives { get; set; } = [];

    public ObservableCollection<TerritorialBarrierDetailDtoModel> TerritorialBarriers { get; set; } = [];

    public ObservableCollection<TerritoryPotentialDetailDtoModel> TerritoryPotentials { get; set; } = [];

    public ObservableCollection<PublicPolicyGroupViewModel> PublicPolicyGroups { get; set; } = [];

    public void LoadSummary()
    {
        if (IsBusy) return;

        IsBusy = true;

        Task.Run(async () =>
        {
            IHttpClientProviderPort httpClientProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

            FeatureQueryApiClient featureQueryApiClient = new(httpClientProvider);
            ObjectiveQueryApiClient objectiveApiClient = new(httpClientProvider);
            TerritorialBarrierQueryApiClient territorialBarrierApiClient = new(httpClientProvider);
            TerritoryPotentialQueryApiClient territoryPotentialApiClient = new(httpClientProvider);
            PublicPolicyQueryApiClient publicPolicyApiClient = new(httpClientProvider);

            FeatureDetailDtoModel[] features = await featureQueryApiClient.GetAllAsync();
            ObjectiveDetailDtoModel[] objectives = [.. (await objectiveApiClient.GetAllAsync()).OrderBy(item => item.Index)];
            TerritorialBarrierDetailDtoModel[] territorialBarriers = await territorialBarrierApiClient.GetAllAsync();
            TerritoryPotentialDetailDtoModel[] territoryPotentials = await territoryPotentialApiClient.GetAllAsync();
            PublicPolicyDetailDtoModel[] publicPolicies = await publicPolicyApiClient.GetAllAsync();

            List<PublicPolicyGroupViewModel> publicPolicyGroups = 
            [
                new PublicPolicyGroupViewModel(PublicPolicyKind.National, [.. publicPolicies.Where(item => item.Kind == PublicPolicyKind.National)]),
                new PublicPolicyGroupViewModel(PublicPolicyKind.Territorial, [.. publicPolicies.Where(item => item.Kind == PublicPolicyKind.Territorial)]),
                new PublicPolicyGroupViewModel(PublicPolicyKind.Provincial, [.. publicPolicies.Where(item => item.Kind == PublicPolicyKind.Provincial)]), 
                new PublicPolicyGroupViewModel(PublicPolicyKind.Municipal, [.. publicPolicies.Where(item => item.Kind == PublicPolicyKind.Municipal)])    
            ];

            Dispatcher.Dispatch(() =>
            {
                LoadedAt = DateTime.Now;

                Features.Clear();

                foreach (FeatureDetailDtoModel item in features)
                {
                    Features.Add(item);
                }

                Objectives.Clear();

                foreach (ObjectiveDetailDtoModel item in objectives)
                {
                    Objectives.Add(item);
                }

                TerritorialBarriers.Clear();

                foreach (TerritorialBarrierDetailDtoModel item in territorialBarriers)
                {
                    TerritorialBarriers.Add(item);
                }

                TerritoryPotentials.Clear();

                foreach (TerritoryPotentialDetailDtoModel item in territoryPotentials)
                {
                    TerritoryPotentials.Add(item);
                }

                PublicPolicyGroups.Clear();

                foreach (PublicPolicyGroupViewModel item in publicPolicyGroups)
                {
                    if (item.Items.Length <= 0) continue;

                    PublicPolicyGroups.Add(item);
                }
            });
        }).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.IsFaulted || task.IsCanceled)
                {
                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                }

                IsBusy = false;
            });
        });
    }
}
