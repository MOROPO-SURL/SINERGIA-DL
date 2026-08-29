using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Entities;

public class StrategicLineAction : AbstractEntity<StrategicLineActionId, Guid>, IPriorizableEntity<StrategicLineActionId, Guid>
{
    private StrategicLineAction() : base(new StrategicLineActionId(default)) { }

    public StrategicLineAction(StrategicLineActionId id, StrategicLineId strategicLineId, string title, int priority, string? description = null) : base(id)
    {
        StrategicLineId = strategicLineId;
        Title = title;
        Priority = priority;
        Description = description;
    }

    public StrategicLineId StrategicLineId { get; set; }

    public string Title { get; set; } = null!;

    public int Priority { get; set; }

    public string? Description { get; set; }
}
