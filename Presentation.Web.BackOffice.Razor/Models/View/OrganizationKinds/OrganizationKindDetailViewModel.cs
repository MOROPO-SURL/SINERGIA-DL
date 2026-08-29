using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.OrganizationKinds;

public record OrganizationKindDetailViewModel(
    Guid Id, 
    string Name, 
    bool IsEnabled,
    DevelopmentActorProfileKind? DevelopmentActorProfileKind = null,
    string? Description = null);