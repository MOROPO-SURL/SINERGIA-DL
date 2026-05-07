using System.ComponentModel.DataAnnotations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicProjectKinds.Abstractions;

public abstract class AbstractStrategicProjectKindConfigurationViewModel
{
    [Required]
    [StringLength(120, MinimumLength = 3)]
    [Display(Name = nameof(Name))]
    public string Name { get; set; } = null!;

    public bool IsEnabled { get; set; }

    [DataType(DataType.MultilineText)]
    [Display(Name = nameof(Description))]
    [StringLength(480, MinimumLength = 3)]
    public string? Description { get; set; }
}