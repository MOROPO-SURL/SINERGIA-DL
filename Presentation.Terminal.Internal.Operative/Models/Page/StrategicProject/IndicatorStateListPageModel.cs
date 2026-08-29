using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject;

public sealed class IndicatorStateListPageModel : AbstractListEntityPageModel<StrategicProjectIndicatorStateViewModel>
{
    public IndicatorStateListPageModel(StrategicProjectDetailDtoModel project)
    {
        Project = project;
    }

    public StrategicProjectDetailDtoModel Project { get; init; }

    protected override async Task<PaginateResultModel<StrategicProjectIndicatorStateViewModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        StrategicProjectIndicatorChangeQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        IndicatorChangeDetailDtoModel[] lastChanges = await apiClient.GetLastsByProjectAsync(Project.Id);

        List<StrategicProjectIndicatorStateViewModel> items = [];

        foreach (IndicatorDetailDtoModel indicator in Project.Indicators)
        {
            IndicatorMilestoneDetailDtoModel? targetMilestone = indicator.Milestones.FirstOrDefault(_item => _item.At.Year == DateTime.Now.Year);
            
            if (targetMilestone == null) continue;
            
            items.Add(new StrategicProjectIndicatorStateViewModel(indicator, targetMilestone!, lastChanges.FirstOrDefault(_item => _item.ProjectId == Project.Id && _item.IndicatorId == indicator.Id)));
        }

        return new PaginateResultModel<StrategicProjectIndicatorStateViewModel>
        {
            Page = 1,
            Limit = items.Count,
            HasNext = false,
            HasPrevious = false,
            MaxPageCount = 1,
            Items = [.. items]
        };
    }
}