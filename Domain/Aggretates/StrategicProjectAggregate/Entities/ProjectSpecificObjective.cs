using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Entities;

public class ProjectSpecificObjective : AbstractAuditableEntity<ProjectSpecificObjectiveId, Guid>
{
    private ProjectSpecificObjective() : base(default) { }

    public ProjectSpecificObjective(ProjectSpecificObjectiveId id, StrategicProjectId projectId, int index, string content) : base(id)
    {
        ProjectId = projectId;
        Index = index;
        Content = content;
    }

    public StrategicProjectId ProjectId { get; set; }

    public int Index { get; set; }

    public string Content { get; set; } = null!;
}
