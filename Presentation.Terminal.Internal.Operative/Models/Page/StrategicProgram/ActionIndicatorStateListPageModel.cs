using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram;

public sealed class ActionIndicatorStateListPageModel : AbstractListEntityPageModel<StrategicProgramIndicatorStateActionGroupedViewModel>
{
    public ActionIndicatorStateListPageModel(StrategicProgramDetailDtoModel program)
    {
        Program = program;
    }

    public StrategicProgramDetailDtoModel Program { get; init; }

    protected override async Task<PaginateResultModel<StrategicProgramIndicatorStateActionGroupedViewModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        StrategicProgramActionIndicatorChangeQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        IndicatorChangeDetailDtoModel[] lastChanges = await apiClient.GetLastsByProgramAsync(Program.Id);

        List<StrategicProgramIndicatorStateActionGroupedViewModel> groups = [];

        foreach (ActionDetailDtoModel action in Program.Actions)
        {
            List<StrategicProgramIndicatorStateViewModel> items = [];

            foreach (ActionIndicatorDetailDtoModel indicator in action.Indicators)
            {
                ActionIndicatorMilestoneDetailDtoModel? targetMilestone = indicator.Milestones.FirstOrDefault(_item => _item.At.Year == DateTime.Now.Year);

                if (targetMilestone == null) continue;

                items.Add(new StrategicProgramIndicatorStateViewModel(action.Id, indicator, targetMilestone!, lastChanges.FirstOrDefault(_item => _item.ProgramId == Program.Id && _item.ActionId == action.Id && _item.IndicatorId == indicator.Id)));
            }

            groups.Add(new StrategicProgramIndicatorStateActionGroupedViewModel(action, items));
        }

        return new PaginateResultModel<StrategicProgramIndicatorStateActionGroupedViewModel>
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
