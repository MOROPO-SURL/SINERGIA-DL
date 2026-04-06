using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges
{
    public class StrategicLineOrganizationBridge : IBridge<StrategicLine, StrategicLineId, Organization, OrganizationId>
    {
        private StrategicLineOrganizationBridge() { }

        public StrategicLineOrganizationBridge(StrategicLineId mainId, StrategicLine main, OrganizationId linkedId, Organization linked)
        {
            MainId = mainId;
            Main = main;
            LinkedId = linkedId;
            Linked = linked;
        }

        public StrategicLineId MainId { get ; set ; }
        public StrategicLine Main { get ; set ; } = null!;

        public OrganizationId LinkedId { get ; set ; }
        public Organization Linked { get ; set ; } = null!;
    }
}
