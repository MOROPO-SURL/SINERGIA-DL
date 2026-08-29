using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.OrganizationKinds.Abstractions;

public abstract class AbstractOrganizationKindConfigurationViewModel
{
    [Required]
    [StringLength(120, MinimumLength = 3)]
    [Display(Name = nameof(Name))]
    public string Name { get; set; } = null!;

    public bool IsEnabled { get; set; }

    [Display(Name = nameof(DevelopmentActorProfileKind))]
    public DevelopmentActorProfileKind? DevelopmentActorProfileKind { get; set; }

    [DataType(DataType.MultilineText)]
    [Display(Name = nameof(Description))]
    [StringLength(480, MinimumLength = 3)]
    public string? Description { get; set; }
}
