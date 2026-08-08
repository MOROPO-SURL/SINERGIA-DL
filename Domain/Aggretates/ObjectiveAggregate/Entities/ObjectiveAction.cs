using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Entities;

public class ObjectiveAction : AbstractEntity<ObjectiveActionId, Guid>
{
    private readonly List<ObjectiveActionIndicator> indicators = [];

    private ObjectiveAction() : base(new ObjectiveActionId(default)) { }

    public ObjectiveAction(
        ObjectiveActionId id, 
        ObjectiveId objectiveId, 
        int index, 
        string title,
        IEnumerable<ObjectiveActionIndicator> indicators,
        string? description = null) : base(id)
    {
        ObjectiveId = objectiveId;
        Index = index;
        Title = title;
        Description = description;

        this.indicators = [.. indicators];
    }

    public ObjectiveId ObjectiveId { get; set; }

    public int Index { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public IReadOnlyList<ObjectiveActionIndicator> Indicators => [.. indicators];

    public void AddIndicator(ObjectiveActionIndicator entity)
    {
        indicators.Add(entity);
    }

    public void RemoveIndicator(ObjectiveActionIndicator entity)
    {
        indicators.Remove(indicators.First(_entity => _entity.Id == entity.Id && _entity.ActionId == entity.ActionId && _entity.ObjectiveId == entity.ObjectiveId));
    }
}