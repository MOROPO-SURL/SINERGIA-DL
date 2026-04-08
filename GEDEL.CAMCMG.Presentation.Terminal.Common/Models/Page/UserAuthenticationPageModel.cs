namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page;

public class UserAuthenticationPageModel : BasePageModel
{
    private string? userName;

    private string? password;

    public string? UserName
    {
        get => userName;
        set => SetProperty(ref userName, value);
    }

    public string? Password
    {
        get => password;
        set => SetProperty(ref password, value);
    }
}
