using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Converters;

internal class NullableUserIdConverter : ValueConverter<UserId?, string?>
{
    public NullableUserIdConverter()
        : base(
            id => id == null ? null : id.Value.Value,
            value => value == null ? null : new UserId(value))
    {
    }
}