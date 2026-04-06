namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Session
{
    public class SessionProfileDetailViewModel
    {
        public string Name { get; set; } = null!;

        public string? LastName { get; set; }

        public string? Alias { get; set; }

        public string? About { get; set; }

        public Guid? ImageId { get; set; }

        public string? ImageExtension { get; set; }
    }
}
