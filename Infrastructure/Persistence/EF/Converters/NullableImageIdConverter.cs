using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Converters;

internal sealed class NullableImageIdConverter : ValueConverter<ImageId?, Guid?>
{
    public NullableImageIdConverter() : base(
        id => id == null ? null : id.Value.Value, 
        value => value == null ? null : new ImageId(value.Value))
    {
    }
}
