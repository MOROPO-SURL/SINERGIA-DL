using System.ComponentModel.DataAnnotations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Session;

public class SessionChangePasswordUpdateViewModel
{
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = nameof(CurrentPassword))]
    public string CurrentPassword { get; set; } = null!;

    [Required]
    [StringLength(80, MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = nameof(NewPassword))]
    public string NewPassword { get; set; } = null!;

    [DataType(DataType.Password)]
    [Compare(nameof(NewPassword))]
    [Display(Name = nameof(ConfirmPassword))]
    public string ConfirmPassword { get; set; } = null!;
}
