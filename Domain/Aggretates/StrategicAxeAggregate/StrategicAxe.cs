using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate;

public class StrategicAxe :
    AbstractAuditableEntity<StrategicAxeId, int>, 
    IAggregateRoot<StrategicAxeId, int>, 
    IArchivableEntity<StrategicAxeId, int>,
    INamedEntity<StrategicAxeId, int>, 
    IEnableableEntity<StrategicAxeId, int>
{
    private readonly List<StrategicAxeMacroprogramBridge> macroprogramBridges = [];

    private StrategicAxe() : base(new StrategicAxeId(default)) { }

    public StrategicAxe(StrategicAxeId id, bool isArchived, string name, bool isEnabled, StrategicAxeMacroprogramBridge[] macroprogramBridges, Person? coordinator = null, PersonId? coordinatorId = null, string? description = null) : base(id)
    {
        IsArchived = isArchived;
        Name = name;
        Description = description;
        IsEnabled = isEnabled;
        CoordinatorId = coordinatorId;
        Coordinator = coordinator;

        this.macroprogramBridges = [.. macroprogramBridges];
    }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public Person? Coordinator { get; set; }
    public PersonId? CoordinatorId { get; set; }

    public string? Description { get; set; }

    public IReadOnlyList<StrategicAxeMacroprogramBridge> MacroprogramBridges => [.. macroprogramBridges];

    public void LinkMacroprogramById(MacroprogramId macroprogramId) => macroprogramBridges.Add(new StrategicAxeMacroprogramBridge(Id, macroprogramId));

    public void UnlinkMacroprogramById(MacroprogramId macroprogramId) => macroprogramBridges.Remove(macroprogramBridges.First(bridge => bridge.LinkedId == macroprogramId));
}
