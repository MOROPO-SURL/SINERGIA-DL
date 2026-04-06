using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;

namespace MOROPO.GEDET.CAM.Infrastructure.Extensions;

public static class StringExtensions
{
    private const string PREMISSION_DESCRIPTION_SUFFIX = "-description";

    public static Permission ToPermissionEntity(this string self, string? family = null)
    {
        return new Permission(new Domain.Aggretates.PermissionAggregate.Values.PermissionId(self), family, $"{self}{PREMISSION_DESCRIPTION_SUFFIX}");
    }
}