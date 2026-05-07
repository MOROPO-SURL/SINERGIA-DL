using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Common.Input;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Users.Abstractions;

public abstract class AbstractUserConfigurationViewModel
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Display(Name = nameof(Id))]
    public string Id { get; set; } = null!;

    [Display(Name = "Roles")]
    public SelectionItemInputViewModel<Guid>[] SelectableRoles { get; set; } = [];

    public bool HasFullAccess { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsPasswordChangeRequired { get; set; }

    [Required]
    [Display(Name = nameof(Name))]
    public string Name { get; set; } = null!;

    [Display(Name = nameof(LastName))]
    public string? LastName { get; set; }

    [FileExtensions]
    [Display(Name = nameof(ImageFile))]
    public IFormFile? ImageFile { get; set; }

    public bool ResetImage { get; set; }

    public Guid? ImageId { get; set; }

    public string? ImageExtension { get; set; }
}