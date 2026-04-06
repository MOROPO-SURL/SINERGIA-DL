using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities
{
    public class StrategicAction: AbstractEntity<StrategicActionId>
    {
        private StrategicAction() : base(new StrategicActionId(default)) { }

        public StrategicAction(StrategicActionId id, int index, string title, string? description): base(id)
        {
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
}
