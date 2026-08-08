using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram;

public sealed class ActionIndicatorStateListPageModel : AbstractListEntityPageModel<IndicatorStateActionGroupedViewModel>
{
    public ActionIndicatorStateListPageModel(StrategicProgramDetailDtoModel program)
    {
        Program = program;
    }

    public StrategicProgramDetailDtoModel Program { get; init; }

    protected override async Task<PaginateResultModel<IndicatorStateActionGroupedViewModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        StrategicProgramActionIndicatorChangeQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        IndicatorChangeDetailDtoModel[] lastChanges = await apiClient.GetLastsByProgramAsync(Program.Id);

        List<IndicatorStateActionGroupedViewModel> groups = [];

        foreach (ActionDetailDtoModel action in Program.Actions)
        {
            List<IndicatorStateViewModel> items = [];

            foreach (ActionIndicatorDetailDtoModel indicator in action.Indicators)
            {
                ActionIndicatorMilestoneDetailDtoModel? targetMilestone = indicator.Milestones.FirstOrDefault(_item => _item.At.Year == DateTime.Now.Year);

                if (targetMilestone == null) continue;

                items.Add(new IndicatorStateViewModel(action.Id, indicator, targetMilestone!, lastChanges.FirstOrDefault(_item => _item.ProgramId == Program.Id && _item.ActionId == action.Id && _item.IndicatorId == indicator.Id)));
            }

            groups.Add(new IndicatorStateActionGroupedViewModel(action, items));
        }

        return new PaginateResultModel<IndicatorStateActionGroupedViewModel>
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
