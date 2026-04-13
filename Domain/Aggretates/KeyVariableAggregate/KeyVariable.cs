using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate;

public class KeyVariable : AbstractEntity<KeyVariableId, Guid>, IAggregateRoot<KeyVariableId, Guid>, IPriorizableEntity<KeyVariableId, Guid>, IArchivableEntity<KeyVariableId, Guid>, INamedEntity<KeyVariableId, Guid>
{
    private KeyVariable() : base(new KeyVariableId(default)) { }

    public KeyVariable(KeyVariableId id, bool isArchived, int priority, string name, string? alias = null, string? description = null) : base(id)
    {
        IsArchived = isArchived;
        Priority = priority;
        Name = name;
        Alias = alias;
        Description = description;
    }

    public bool IsArchived { get; set; }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public string? Alias { get; set; }

    public string? Description { get; set; }
}
