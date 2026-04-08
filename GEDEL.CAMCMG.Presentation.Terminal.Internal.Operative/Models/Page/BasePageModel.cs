namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page;

public class BasePageModel : BaseBindableModel
{
    protected bool busy;
    private string? busyProgressMessage;

    public bool IsBusy
    {
        get { return busy; }
        set { SetProperty(ref busy, value); }
    }

    public string? BusyProgressMessage
    {
        get => busyProgressMessage;
        set => SetProperty(ref busyProgressMessage, value);
    }
}
