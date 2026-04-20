using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Permissions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.ApiKeys;

public record ApiKeyDetailViewModel(Guid Id, string Name, DateTime ExpireAt, string Token, DateTime CreatedAt, PermissionDetailViewModel[] Permissions, DateTime? UpdatedAt = null, string? Host = null, string? Description = null);