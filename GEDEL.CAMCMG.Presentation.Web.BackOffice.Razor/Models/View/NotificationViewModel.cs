using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View;

public class NotificationViewModel
{
    public NotificationKind Kind { get; set; }

    public DateTime At { get; private set; } = DateTime.Now;

    public string? MainMessage { get; set; }

    public string? Title { get; set; }

    public string[]? DetailMessages { get; set; }
}
