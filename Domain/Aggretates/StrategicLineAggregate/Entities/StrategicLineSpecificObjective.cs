using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Entities;

public sealed class StrategicLineSpecificObjective : AbstractEntity<StrategicLineSpecificObjectiveId, Guid>
{
    private StrategicLineSpecificObjective() : base(new StrategicLineSpecificObjectiveId(default)) { }

    public StrategicLineSpecificObjective(StrategicLineSpecificObjectiveId id, StrategicLineId strategicLineId, int index, string content) : base(id)
    {
        StrategicLineId = strategicLineId;
        Index = index;
        Content = content;
    }

    public StrategicLineId StrategicLineId { get; set; }

    public int Index { get; set; }

    public string Content { get; set; } = null!;
}