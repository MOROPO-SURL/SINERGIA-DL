using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;

namespace MOROPO.GEDET.CAM.Domain.Bridges
{
    public class StrategicProgramOrganizationBridge : IBridge<StrategicProgram, StrategicProgramId, Organization, OrganizationId>
    {
        private StrategicProgramOrganizationBridge() { }

        public StrategicProgramOrganizationBridge(StrategicProgramId mainId, StrategicProgram main, OrganizationId linkedId, Organization linked)
        {
            MainId = mainId;
            Main = main;
            LinkedId = linkedId;
            Linked = linked;
        }

        public StrategicProgramId MainId { get ; set ; }
        public StrategicProgram Main { get ; set ; } = null!;

        public OrganizationId LinkedId { get ; set ; }
        public Organization Linked { get ; set ; } = null!;
    }
}
