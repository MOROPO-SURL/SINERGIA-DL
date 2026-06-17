using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Converters;

public sealed class NullableStrategicAxeIdConverter : ValueConverter<StrategicAxeId?, int?>
{
    public NullableStrategicAxeIdConverter()
        : base(
            id => id == null ? null : id.Value.Value,
            value => value == null ? null : new StrategicAxeId(value.Value))
    {
    }
}