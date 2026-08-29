using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate;

public sealed class EconomicActivity : AbstractEntity<EconomicActivityId, int>, IAggregateRoot<EconomicActivityId, int>, IEnableableEntity<EconomicActivityId, int>, IArchivableEntity<EconomicActivityId, int>
{
    public EconomicActivity(EconomicActivityId id, string name) : base(id)
    {
        Name = name;
    }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public string Name { get; set; }
}