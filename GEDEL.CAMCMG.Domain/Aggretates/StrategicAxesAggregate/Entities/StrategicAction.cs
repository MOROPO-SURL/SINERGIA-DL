using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;

public class StrategicAction : AbstractEntity<StrategicActionId, Guid>
{
    private StrategicAction() : base(new StrategicActionId(default)) { }

    public StrategicAction(StrategicActionId id, StrategicLineId strategicLineId, StrategicAxesId strategicAxesId, int index, string title, string? description = null) : base(id)
    {
        StrategicLineId = strategicLineId;
        StrategicAxesId = strategicAxesId;
        Index = index;
        Title = title;
        Description = description;
    }

    public StrategicAxesId StrategicAxesId { get; set; }

    public StrategicLineId StrategicLineId { get; set; }

    public int Index { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}
