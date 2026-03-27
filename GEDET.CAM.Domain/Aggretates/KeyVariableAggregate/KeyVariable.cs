using MOROPO.GEDET.CAM.Domain.Aggretates.KeyVariableAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.KeyVariableAggregate;

public class KeyVariable : AbstractEntity<KeyVariableId>, IAggregateRoot<KeyVariableId>, IPriorizableEntity<KeyVariableId>, IArchivableEntity<KeyVariableId>, INamedEntity<KeyVariableId>
{
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

    public string Name { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }
}
