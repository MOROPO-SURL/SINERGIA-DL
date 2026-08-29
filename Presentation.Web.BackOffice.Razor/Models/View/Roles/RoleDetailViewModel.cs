using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Permissions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Roles;

public record RoleDetailViewModel(Guid Id, string Name, PermissionDetailViewModel[] Permissions, string? Description);
