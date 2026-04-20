using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Roles;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Users;

public record UserDetailViewModel(string Id, string Name, bool IsEnabled, bool HasFullAccess, bool IsPasswordChangeRequired, DateTime CreatedAt, DateTime? UpdatedAt, RoleDetailViewModel[] Roles, string? LastName = null);