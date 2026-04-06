using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;
using System;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities
{
    public class StrategicLine : AbstractAuditableEntity<StrategicLineId>, IAggregateRoot<StrategicLineId>, IArchivableEntity<StrategicLineId>, INamedEntity<StrategicLineId>, IEnableableEntity<StrategicLineId>
    {
        private readonly List<StrategicAction> strategicActions = [];
        private readonly List<StrategicProgram> strategicPrograms = [];

        private StrategicLine() : base(new StrategicLineId(default)) { }

        public StrategicLine(StrategicLineId id, string? description, int index, bool enabled, string name, bool isArchived, PersonAggregate.Person coordinator, StrategicAction[] strategicActions, StrategicProgram[] strategicPrograms, StrategicLineOrganizationBridge[] organizationBridges) : base(id)
        {
            Description = description;
            Index = index;
            Enabled = enabled;
            Name = name;
            IsArchived = isArchived;
            Coordinator = coordinator;

            this.strategicActions = [.. strategicActions];
            this.strategicPrograms = [.. strategicPrograms];

            OrganizationBridges = [.. organizationBridges];
        }

        public StrategicAxesId StrategicAxesId { get; set; }

        public string? Description { get; set; }

        public int Index { get; set; }
        
        public bool Enabled { get ; set ; }
        
        public string Name { get; set; } = null!;
        
        public bool IsArchived { get ; set ; }

        public PersonAggregate.Person Coordinator { get; set; } = null!;
        public PersonId CoordinadorId { get; set; }

        public StrategicAction[] StrategicActions => [.. strategicActions];

        public StrategicProgram[] StrategicProgram => [.. strategicPrograms];

        public List<StrategicLineOrganizationBridge> OrganizationBridges {  get; set; } = null!;
    }
}
