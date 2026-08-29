using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Entities;

public class ProgramAction : AbstractEntity<ProgramActionId, Guid>, IPriorizableEntity<ProgramActionId, Guid>
{
    private readonly List<ProgramActionIndicator> indicators = [];
    private readonly List<ProgramActionInterestAreaBridge> interestAreaBridges = [];

    private ProgramAction() : base(default) { }

    public ProgramAction(
        ProgramActionId id, 
        StrategicProgramId programId, 
        string title, 
        int priority, 
        IEnumerable<ProgramActionIndicator> indicators,
        IEnumerable<ProgramActionInterestAreaBridge> interestAreaBridges, 
        string? description = null) : base(id)
    {
        ProgramId = programId;
        Priority = priority;
        Title = title;
        Description = description;

        this.indicators = [.. indicators];
        this.interestAreaBridges = [.. interestAreaBridges];
    }

    public StrategicProgramId ProgramId { get; set; }

    public string Title { get; set; } = null!;

    public int Priority { get; set; }

    public string? Description { get; set; }

    public IReadOnlyList<ProgramActionIndicator> Indicators => [.. indicators];

    public IReadOnlyList<ProgramActionInterestAreaBridge> InterestAreaBridges => [.. interestAreaBridges];

    public void AddIndicator(ProgramActionIndicator entity)
    {
        indicators.Add(entity);
    }

    public void RemoveIndicator(ProgramActionIndicator entity) 
    {
        indicators.Remove(indicators.First(_entity => _entity.Id == entity.Id && _entity.ActionId == entity.ActionId && _entity.ProgramId == entity.ProgramId));
    }
}