using System.ComponentModel.DataAnnotations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Users;

public class UserChangePasswordViewModel
{
    [Required]
    public string UserId { get; set; } = null!;

    public bool IsChangePasswordRequired { get; set; }

    [DataType(DataType.Password)]
    [Required]
    [StringLength(80, MinimumLength = 6)]
    [Display(Name = nameof(NewPassword))]
    public string NewPassword { get; set; } = null!;

    [DataType(DataType.Password)]
    [Compare(nameof(NewPassword))]
    [Display(Name = nameof(ConfirmPassword))]
    public string ConfirmPassword { get; set; } = null!;
}
