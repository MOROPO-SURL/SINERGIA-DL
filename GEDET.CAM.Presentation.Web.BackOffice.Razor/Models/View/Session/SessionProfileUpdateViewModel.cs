using System.ComponentModel.DataAnnotations;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Session;

public class SessionProfileUpdateViewModel
{
    [Required]
    [Display(Name = nameof(Name))]
    public string Name { get; set; } = null!;

    [Display(Name = nameof(LastName))]
    public string? LastName { get; set; }

    [Display(Name = nameof(Alias))]
    public string? Alias { get; set; }

    [Display(Name = nameof(About))]
    public string? About { get; set; }

    [FileExtensions()]
    [Display(Name = nameof(ImageFile))]
    public IFormFile? ImageFile { get; set; }

    public bool ResetImage { get; set; }

    public Guid? ImageId { get; set; }

    public string? ImageExtension { get; set; }
}
