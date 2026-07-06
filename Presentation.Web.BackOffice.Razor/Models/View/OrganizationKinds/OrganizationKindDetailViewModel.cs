using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.OrganizationKinds;

public record OrganizationKindDetailViewModel(
    Guid Id, 
    string Name, 
    bool IsEnabled,
    DevelopmentActorProfileKind? DevelopmentActorProfileKind = null,
    string? Description = null);