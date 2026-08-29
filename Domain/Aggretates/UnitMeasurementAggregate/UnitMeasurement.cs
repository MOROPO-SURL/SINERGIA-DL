using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate;

public class UnitMeasurement : AbstractAuditableEntity<UnitMeasurementId, Guid>, IAggregateRoot<UnitMeasurementId, Guid>, INamedEntity<UnitMeasurementId, Guid>, IArchivableEntity<UnitMeasurementId, Guid>, IEnableableEntity<UnitMeasurementId, Guid>, IPriorizableEntity<UnitMeasurementId, Guid>
{
    private UnitMeasurement() : base(new UnitMeasurementId(default)) { }

    public UnitMeasurement(UnitMeasurementId id, bool isEnabled, bool isArchived, string name, string symbol, bool prefixed) : base(id)
    {
        IsEnabled = isEnabled;
        IsArchived = isArchived;
        Name = name;
        Symbol = symbol;
        Prefixed = prefixed;
    }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public bool Prefixed { get; set; }
}