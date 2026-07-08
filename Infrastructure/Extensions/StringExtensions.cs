using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PermissionAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Extensions;

public static class StringExtensions
{
    private const string PREMISSION_DESCRIPTION_SUFFIX = "-description";

    public static Permission ToPermissionEntity(this string self, string? family = null)
    {
        return new Permission(new Domain.Aggretates.PermissionAggregate.Values.PermissionId(self), family, $"{self}{PREMISSION_DESCRIPTION_SUFFIX}");
    }

    internal static string ToDefaultFileStorageCategory(this string contentType)
    {
        if (contentType.StartsWith("image/")) return "images";

        if (contentType.StartsWith("video/")) return "videos";

        return "documents";
    }
}