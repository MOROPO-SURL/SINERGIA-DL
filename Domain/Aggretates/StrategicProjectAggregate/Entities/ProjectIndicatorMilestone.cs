using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Entities;

public sealed class ProjectIndicatorMilestone : AbstractEntity<ProjectIndicatorMilestoneId, Guid>
{
    private ProjectIndicatorMilestone() : base(default) { }

    public ProjectIndicatorMilestone(ProjectIndicatorMilestoneId id, ProjectIndicatorId indicatorId, StrategicProjectId projectId, DateOnly at, float amount, string? description = null) : base(id)
    {
        ProjectId = projectId;
        IndicatorId = indicatorId;
        Amount = amount;
        Description = description;
    }

    public StrategicProjectId ProjectId { get; set; }

    public ProjectIndicatorId IndicatorId { get; set; }

    public DateOnly At { get; set; }

    public float Amount { get; set; }

    public string? Description { get; set; }
}
