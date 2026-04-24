using System.ComponentModel.DataAnnotations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.FeatureKinds.Abstractions;

public abstract class AbstractFeatureKindConfigurationViewModel
{
    [Required]
    [StringLength(360, MinimumLength = 3)]
    [Display(Name = nameof(Name))]
    public string Name { get; set; } = null!;

    public int Priority { get; set; } = 1;

    public bool IsEnabled { get; set; }

    [DataType(DataType.MultilineText)]
    [Display(Name = nameof(Description))]
    [StringLength(1024, MinimumLength = 3)]
    public string? Description { get; set; }
}
