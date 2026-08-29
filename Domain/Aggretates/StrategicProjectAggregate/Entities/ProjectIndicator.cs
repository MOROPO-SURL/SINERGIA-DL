using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Entities;

public class ProjectIndicator : AbstractAuditableEntity<ProjectIndicatorId, Guid>, INamedEntity<ProjectIndicatorId, Guid>, IPriorizableEntity<ProjectIndicatorId, Guid>
{
    private readonly List<ProjectIndicatorMilestone> milestones = [];
    private readonly List<ProjectIndicatorChange> changes = [];

    private ProjectIndicator() : base(default) { }

    public ProjectIndicator(
        ProjectIndicatorId id,
        StrategicProjectId projectId,
        string name,
        UnitMeasurementId unitMeasurementId,
        int priority,
        IEnumerable<ProjectIndicatorMilestone> milestones,
        string? alias = null,
        UnitMeasurement? unitMeasurement = null) : base(id)
    {
        ProjectId = projectId;
        Name = name;
        UnitMeasurementId = unitMeasurementId;
        Priority = priority;
        Alias = alias;
        UnitMeasurement = unitMeasurement;

        this.milestones = [.. milestones];
    }

    public StrategicProjectId ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Alias { get; set; }

    public UnitMeasurementId UnitMeasurementId { get; set; }
    public UnitMeasurement? UnitMeasurement { get; set; }

    public int Priority { get; set; }

    public IReadOnlyList<ProjectIndicatorMilestone> Milestones => [.. milestones];

    public IReadOnlyList<ProjectIndicatorChange> Changes => [.. changes];

    public void AddMilestone(ProjectIndicatorMilestone entity) => milestones.Add(entity);

    public void RemoveMilestone(ProjectIndicatorMilestone entity) => milestones.Remove(entity);

    public void AddChange(ProjectIndicatorChange entity) => changes.Add(entity);

    public void RemoveChange(ProjectIndicatorChange entity) => changes.Remove(entity);
}
