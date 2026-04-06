using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges
{
    public class ProgramExecutionProyectProgramObjetiveBridge : IBridge<ProgramExecutionProyect, ProgramExecutionProyectId, ProgramObjetive, ProgramObjetiveId>
    {
        private ProgramExecutionProyectProgramObjetiveBridge() { }

        public ProgramExecutionProyectProgramObjetiveBridge(ProgramExecutionProyectId mainId, ProgramExecutionProyect main, ProgramObjetiveId linkedId, ProgramObjetive linked)
        {
            MainId = mainId;
            Main = main;
            LinkedId = linkedId;
            Linked = linked;
        }

        public ProgramExecutionProyectId MainId { get ; set ; }
        public ProgramExecutionProyect Main { get ; set ; } = null!;

        public ProgramObjetiveId LinkedId { get ; set ; }
        public ProgramObjetive Linked { get ; set ; } = null!;
    }
}
