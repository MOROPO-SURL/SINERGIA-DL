using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;

public class ProgramActionIndicator : AbstractAuditableEntity<ProgramActionIndicatorId, Guid>, INamedEntity<ProgramActionIndicatorId, Guid>, IPriorizableEntity<ProgramActionIndicatorId, Guid>
{
    private readonly List<ProgramActionIndicatorMilestone> milestones = [];
    private readonly List<ProgramActionIndicatorChange> changes = [];

    private ProgramActionIndicator() : base(default) { }

    public ProgramActionIndicator(
        ProgramActionIndicatorId id, 
        ProgramActionId actionId, 
        StrategicProgramId programId,
        string name, 
        UnitMeasurementId unitMeasurementId, 
        int priority,
        IEnumerable<ProgramActionIndicatorMilestone> milestones,
        string? alias = null, 
        UnitMeasurement? unitMeasurement = null) : base(id)
    {
        ActionId = actionId;
        ProgramId = programId;
        Name = name;
        UnitMeasurementId = unitMeasurementId;
        Priority = priority;
        Alias = alias;
        UnitMeasurement = unitMeasurement;

        this.milestones = [.. milestones];
    }

    public StrategicProgramId ProgramId { get; set; }

    public ProgramActionId ActionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Alias { get; set; }

    public UnitMeasurementId UnitMeasurementId { get; set; }
    public UnitMeasurement? UnitMeasurement { get; set; }

    public int Priority { get; set; }

    public IReadOnlyList<ProgramActionIndicatorMilestone> Milestones => [.. milestones];

    public IReadOnlyList<ProgramActionIndicatorChange> Changes => [.. changes];

    public void AddMilestone(ProgramActionIndicatorMilestone entity) => milestones.Add(entity);

    public void RemoveMilestone(ProgramActionIndicatorMilestone entity) => milestones.Remove(entity);

    public void AddChange(ProgramActionIndicatorChange entity) => changes.Add(entity);

    public void RemoveChange(ProgramActionIndicatorChange entity) => changes.Remove(entity);
}
