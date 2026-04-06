using MOROPO.GEDET.CAM.Domain.Aggretates.KeyVariableAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.MacroprogramsAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.MacroprogramsAggregate
{
    public class Macroprograms : AbstractAuditableEntity<MacroprogramsId>, IAggregateRoot<MacroprogramsId>, IArchivableEntity<MacroprogramsId>
    {
        private Macroprograms() : base(new MacroprogramsId(default)) { }

        public Macroprograms(MacroprogramsId id, bool isArchived, string title, int index, string? description = null) : base(id)
        {
            IsArchived = isArchived;
            Title = title;
            Index = index;
            Description = description;
        }

        public bool IsArchived { get ; set ; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int Index { get; set; }
    }
}
