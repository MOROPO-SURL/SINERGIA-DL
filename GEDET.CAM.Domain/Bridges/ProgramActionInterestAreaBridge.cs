using MOROPO.GEDET.CAM.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges
{
    public class ProgramActionInterestAreaBridge : IBridge<ProgramAction, ProgramActionId, InterestArea, InterestAreaId>
    {
        private ProgramActionInterestAreaBridge() { }

        public ProgramActionInterestAreaBridge(ProgramActionId mainId, ProgramAction main, InterestAreaId linkedId, InterestArea linked)
        {
            MainId = mainId;
            Main = main;
            LinkedId = linkedId;
            Linked = linked;
        }

        public ProgramActionId MainId { get ; set ; }
        public ProgramAction Main { get ; set ; } = null!;

        public InterestAreaId LinkedId { get ; set ; }
        public InterestArea Linked { get ; set ; } = null!;
    }
}
