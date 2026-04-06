using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities
{
    public class ProgramAction: AbstractEntity<ProgramActionId>
    {
        private ProgramAction() : base(new ProgramActionId(default)) { }

        public ProgramAction(ProgramActionId id, int index, string title, string? description, ProgramActionInterestAreaBridge[] interestAreaBridges) : base(id)
        {
            Index = index;
            Title = title;
            Description = description;

            InterestAreaBridges = [.. interestAreaBridges];
        }

        public StrategicAxesId StrategicAxesId { get; set; }

        public StrategicLineId StrategicLineId { get; set; }

        public StrategicProgramId StrategicProgramId { get; set; }

        public int Index { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public ProgramAction? Parent { get; set; }
        public ProgramActionId? ParentId { get; set; }

        public List<ProgramActionInterestAreaBridge> InterestAreaBridges { get; set; } = null!;
    }
}
