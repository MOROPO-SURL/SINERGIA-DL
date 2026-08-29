using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective;

public sealed class ActionIndicatorStateListPageModel : AbstractListEntityPageModel<ObjectiveIndicatorStateActionGroupedViewModel>
{
    public ActionIndicatorStateListPageModel(ObjectiveDetailDtoModel objective)
    {
        Objective = objective;
    }

    public ObjectiveDetailDtoModel Objective { get; init; }

    protected override async Task<PaginateResultModel<ObjectiveIndicatorStateActionGroupedViewModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        ObjectiveActionIndicatorChangeQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        IndicatorChangeDetailDtoModel[] lastChanges = await apiClient.GetLastsByObjectiveAsync(Objective.Id);

        List<ObjectiveIndicatorStateActionGroupedViewModel> groups = [];

        foreach (ObjectiveActionDetailDtoModel action in Objective.Actions)
        {
            List<ObjectiveIndicatorStateViewModel> items = [];

            foreach (ObjectiveActionIndicatorDetailDtoModel indicator in action.Indicators)
            {
                ObjectiveActionIndicatorMilestoneDetailDtoModel? targetMilestone = indicator.Milestones.FirstOrDefault(_item => _item.At.Year == DateTime.Now.Year);

                if (targetMilestone == null) continue;

                items.Add(new ObjectiveIndicatorStateViewModel(action.Id, indicator, targetMilestone!, lastChanges.FirstOrDefault(_item => _item.ObjectiveId == Objective.Id && _item.ActionId == action.Id && _item.IndicatorId == indicator.Id)));
            }

            groups.Add(new ObjectiveIndicatorStateActionGroupedViewModel(action, items));
        }

        return new PaginateResultModel<ObjectiveIndicatorStateActionGroupedViewModel>
        {
            Page = 1,
            Limit = groups.Count,
            HasNext = false,
            HasPrevious = false,
            MaxPageCount = 1,
            Items = [.. groups]
        };
    }
}
