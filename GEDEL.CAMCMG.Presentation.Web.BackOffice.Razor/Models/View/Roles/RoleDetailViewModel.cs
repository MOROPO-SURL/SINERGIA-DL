using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Permissions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Roles;

public record RoleDetailViewModel(Guid Id, string Name, PermissionDetailViewModel[] Permissions, string? Description);
