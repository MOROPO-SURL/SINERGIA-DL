using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Permissions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.ApiKeys;

public record ApiKeyDetailViewModel(Guid Id, string Name, DateTime ExpireAt, PermissionDetailViewModel[] Permissions, string? Host, string? Description);