using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Common.Input;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Roles.Abstractions;

public abstract class AbstractRoleConfigurationViewModel
{
    [Required(ErrorMessage = "RequiredValidationErrorMessage"), StringLength(50, MinimumLength = 3, ErrorMessage = "StringLengthMinMaxValidationErrorMessage")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [DataType(DataType.MultilineText)]
    [Display(Name = "Description")]
    public string? Description { get; set; }

    public SelectionDescriptedItemInputViewModel<string>[] SelectedPermissions { get; set; } = [];

    public SelectionDescriptedItemInputViewModel<string>[]? UngroupedSelectablePermissions { get; set; }

    public KeyValuePair<string, SelectionDescriptedItemInputViewModel<string>[]>[]? GroupedSelectablePermissions { get; set; }
}
