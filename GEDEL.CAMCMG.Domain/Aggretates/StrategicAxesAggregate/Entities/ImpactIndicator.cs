using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;

public class ImpactIndicator : AbstractAuditableEntity<ImpactIndicatorId, Guid>, INamedEntity<ImpactIndicatorId, Guid>, IArchivableEntity<ImpactIndicatorId, Guid>, IEnableableEntity<ImpactIndicatorId, Guid>
{
    private ImpactIndicator() : base(new ImpactIndicatorId(default)) { }

    public ImpactIndicator(ImpactIndicatorId id, bool isEnabled, bool isArchived, string name, string alias, float meta, UnitMeasurementId unitMeasurementId, UnitMeasurement? unitMeasurement = null) : base(id)
    {
        IsEnabled = isEnabled;
        IsArchived = isArchived;
        Name = name;
        Alias = alias;
        Meta = meta;
        UnitMeasurement = unitMeasurement;
    }

    public StrategicAxesId StrategicAxesId { get; set; }

    public StrategicLineId StrategicLineId { get; set; }

    public StrategicProgramId StrategicProgramId { get; set; }

    public ProgramImpactId ProgramImpactId { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public float Meta { get; set; }

    public UnitMeasurement? UnitMeasurement { get; set; }
    public UnitMeasurementId UnitMeasurementId { get; set; }

}
