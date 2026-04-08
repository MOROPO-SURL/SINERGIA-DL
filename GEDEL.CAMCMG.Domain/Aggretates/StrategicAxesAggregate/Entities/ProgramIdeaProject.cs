using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities
{
    public class ProgramIdeaProject : AbstractAuditableEntity<ProgramIdeaProjectId, Guid>, INamedEntity<ProgramIdeaProjectId, Guid>, IArchivableEntity<ProgramIdeaProjectId, Guid>, IEnableableEntity<ProgramIdeaProjectId, Guid>
    {
        private ProgramIdeaProject() : base(new ProgramIdeaProjectId(default)) { }

        public ProgramIdeaProject(ProgramIdeaProjectId id, StrategicProgramId strategicProgramId, StrategicLineId strategicLineId, StrategicAxesId strategicAxesId, string name, string? description, bool isArchived, bool isEnabled) : base(id)
        {
            StrategicProgramId = strategicProgramId;
            StrategicLineId = strategicLineId;
            StrategicAxesId = strategicAxesId;
            Name = name;
            IsArchived = isArchived;
            IsEnabled = isEnabled;
            Description = description;
        }

        public StrategicAxesId StrategicAxesId { get; set; }

        public StrategicLineId StrategicLineId { get; set; }

        public StrategicProgramId StrategicProgramId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public bool IsArchived { get; set; }

        public bool IsEnabled { get; set; }
    }

}
