using MOROPO.GEDET.CAM.Domain.Aggretates.ClasificationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ClasificationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges
{
    public class OrganizationClasificationBridge : IBridge<Organization, OrganizationId, Clasification, ClasificationId>
    {
        private OrganizationClasificationBridge() { }

        public OrganizationClasificationBridge(OrganizationId mainId, Organization main, ClasificationId linkedId, Clasification linked)
        {
            MainId = mainId;
            Main = main;
            LinkedId = linkedId;
            Linked = linked;
        }

        public OrganizationId MainId { get ; set ; }
        public Organization Main { get ; set ; } = null!;

        public ClasificationId LinkedId { get ; set ; }
        public Clasification Linked { get ; set ; } = null!;
    }
}
