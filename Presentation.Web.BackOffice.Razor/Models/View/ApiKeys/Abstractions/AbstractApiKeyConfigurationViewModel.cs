using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Common.Input;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.ApiKeys.Abstractions;

public abstract class AbstractApiKeyConfigurationViewModel
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Display(Name = nameof(Name))]
    public string Name { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public DateTime ExpireAt { get; set; } = DateTime.Now.AddYears(1);

    [Display(Name = nameof(Host))]
    public string? Host { get; set; }

    [DataType(DataType.MultilineText)]
    [Display(Name = nameof(Description))]
    public string? Description { get; set; }

    public SelectionDescriptedItemInputViewModel<string>[] SelectedPermissions { get; set; } = [];

    public SelectionDescriptedItemInputViewModel<string>[]? UngroupedSelectablePermissions { get; set; }

    public KeyValuePair<string, SelectionDescriptedItemInputViewModel<string>[]>[]? GroupedSelectablePermissions { get; set; }
}
