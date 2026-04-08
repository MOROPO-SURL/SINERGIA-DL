using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Constants;

public static class ManagementDashboardConstants
{
    public readonly static KeyValuePair<string, ManagementDashboardSectionViewModel[]>[] MANAGEMENT_DASHBOARD_SECTIONS =
    [
        new KeyValuePair<string, ManagementDashboardSectionViewModel[]>(
            "Seguridad",
            [
                new  ManagementDashboardSectionViewModel("Usuarios", "users", "Index", "Security", "mdi mdi-account", "any"),
                new  ManagementDashboardSectionViewModel("Roles", "roles", "Index", "Security", "mdi mdi-account-group", "any"),
                new  ManagementDashboardSectionViewModel("Registros", "traces", "Index", "Security", "mdi mdi-foot-print", "any")
            ])
    ];
}
