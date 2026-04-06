using MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Permissions;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Roles;

public record RoleDetailViewModel(Guid Id, string Name, PermissionDetailViewModel[] Permissions, string? Description);
