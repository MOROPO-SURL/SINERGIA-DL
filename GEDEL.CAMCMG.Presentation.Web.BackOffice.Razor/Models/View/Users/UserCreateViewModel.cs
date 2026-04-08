using System.ComponentModel.DataAnnotations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Users;

public sealed class UserCreateViewModel : Abstractions.AbstractUserConfigurationViewModel
{
    [Required]
    [StringLength(30, MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = nameof(Password))]
    public string Password { get; set; } = null!;

    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    [Display(Name = nameof(ConfirmPassword))]
    public string ConfirmPassword { get; set; } = null!;
}
