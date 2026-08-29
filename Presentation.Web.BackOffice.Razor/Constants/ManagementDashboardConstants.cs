using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Constants;

public static class ManagementDashboardConstants
{
    public readonly static KeyValuePair<string, ManagementDashboardSectionViewModel[]>[] MANAGEMENT_DASHBOARD_SECTIONS =
    [
        new KeyValuePair<string, ManagementDashboardSectionViewModel[]>(
            "Seguridad",
            [
                new  ManagementDashboardSectionViewModel("Usuarios", "users", "Index", "Security", "mdi mdi-account-key", "any"),
                new  ManagementDashboardSectionViewModel("Roles", "roles", "Index", "Security", "mdi mdi-account-group", "any"),
                new  ManagementDashboardSectionViewModel("Llaves API", "apikeys", "Index", "Security", "mdi mdi-key", "any"),
                new  ManagementDashboardSectionViewModel("Registros", "usertraces", "Index", "Security", "mdi mdi-foot-print", "any")
            ]),
        new KeyValuePair<string, ManagementDashboardSectionViewModel[]>(
            "Complementarios",
            [
                new  ManagementDashboardSectionViewModel("Macroprogramas", "macroprograms", "Index", "Complement", "mdi mdi-folder-pound", "any"),
                new  ManagementDashboardSectionViewModel("Areas de Interés", "interestareas", "Index", "Complement", "mdi mdi-chart-bubble", "any"),
                new  ManagementDashboardSectionViewModel("Variables Clave", "keyvariables", "Index", "Complement", "mdi mdi-star-four-points", "any"),
                new  ManagementDashboardSectionViewModel("Tipos de Caract. Terr.", "featurekinds", "Index", "Complement", "mdi mdi-checkbox-multiple-marked-circle-outline", "any"),
                new  ManagementDashboardSectionViewModel("Unidades de medida", "unitmeasurements", "Index", "Complement", "mdi mdi-scale", "any"),
                new  ManagementDashboardSectionViewModel("Personas", "people", "Index", "Complement", "mdi mdi-account", "any"),
                new  ManagementDashboardSectionViewModel("Entidades", "organizations", "Index", "Complement", "mdi mdi-domain", "any"),
                new  ManagementDashboardSectionViewModel("Tipos de Entidad", "organizationkinds", "Index", "Complement", "mdi mdi-office-building", "any"),
                new  ManagementDashboardSectionViewModel("Clasificaciones", "classifications", "Index", "Complement", "mdi mdi-star-box-outline", "any"),
                new  ManagementDashboardSectionViewModel("Tipos de Proyecto", "strategicprojectkinds", "Index", "Complement", "mdi mdi-folder-settings-variant-outline", "any"),
                new  ManagementDashboardSectionViewModel("Actividades económica", "economicactivities", "Index", "Complement", "mdi mdi-gold", "any"),
                new  ManagementDashboardSectionViewModel("Modalidades de PDL", "pdlmodalities", "Index", "Complement", "mdi mdi-star-circle", "any")
            ]),
        new KeyValuePair<string, ManagementDashboardSectionViewModel[]>(
            "Diagnóstico",
            [
                new  ManagementDashboardSectionViewModel("Caracter. Territ.", "features", "Index", "Diagnostic", "mdi mdi-checkbox-marked-circle-outline", "any"),
                new  ManagementDashboardSectionViewModel("Objetivos", "objectives", "Index", "Diagnostic", "mdi mdi-bullseye-arrow", "any"),
                new  ManagementDashboardSectionViewModel("Barreras", "territorialbarriers", "Index", "Diagnostic", "mdi mdi-sign-caution", "any"),
                new  ManagementDashboardSectionViewModel("Potencialidades", "territorypotentials", "Index", "Diagnostic", "mdi mdi-arm-flex", "any"),
                new  ManagementDashboardSectionViewModel("Políticas Públicas", "publicpolicies", "Index", "Diagnostic", "mdi mdi-scale-balance", "any")
            ]),
        new KeyValuePair<string, ManagementDashboardSectionViewModel[]>(
            "Estrategia",
            [
                new  ManagementDashboardSectionViewModel("Ejes", "strategicaxes", "Index", "EDL", "mdi mdi-forwardburger", "any"),
                new  ManagementDashboardSectionViewModel("Líneas", "strategiclines", "Index", "EDL", "mdi mdi-arrow-right", "any"),
                new  ManagementDashboardSectionViewModel("Programas", "strategicprograms", "Index", "EDL", "mdi mdi-folder-table-outline", "any"),
                new  ManagementDashboardSectionViewModel("Proyectos", "strategicprojects", "Index", "EDL", "mdi mdi-folder-settings-variant", "any")
            ])
    ];
}
