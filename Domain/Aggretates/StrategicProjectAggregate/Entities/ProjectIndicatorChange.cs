using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Entities;

public sealed class ProjectIndicatorChange : AbstractEntity<ProjectIndicatorChangeId, DateTime>
{
    private ProjectIndicatorChange() : base(default) { }

    public ProjectIndicatorChange(ProjectIndicatorChangeId id, StrategicProjectId projectId, ProjectIndicatorId indicatorId, float amount, string? context = null) : base(id)
    {
        ProjectId = projectId;
        IndicatorId = indicatorId;
        Amount = amount;
        Context = context;
    }

    public StrategicProjectId ProjectId { get; set; }

    public ProjectIndicatorId IndicatorId { get; set; }

    public float Amount { get; set; }

    public string? Context { get; set; }
}
