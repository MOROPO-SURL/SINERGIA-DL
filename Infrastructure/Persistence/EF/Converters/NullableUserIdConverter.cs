using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Converters;

internal class NullableUserIdConverter : ValueConverter<UserId?, string?>
{
    public NullableUserIdConverter()
        : base(
            id => id == null ? null : id.Value.Value,
            value => value == null ? null : new UserId(value))
    {
    }
}