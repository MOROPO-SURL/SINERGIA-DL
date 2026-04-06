using System.ComponentModel.DataAnnotations;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Authentication;

public class AuthenticateRequestModel
{
    [Required]
    [Display(Name = nameof(UserName))]
    public string UserName { get; set; } = null!;

    [Required]
    [Display(Name = nameof(Password))]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    //[Required, Display(Name = nameof(CaptchaCode))]
    //public string? CaptchaCode { get; set; }

    public bool RememberMe { get; set; }
}
