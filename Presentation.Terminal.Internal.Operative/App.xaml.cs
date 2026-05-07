namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new UI.Shells.AppShell();
    }

    protected override void OnStart()
    {
        base.OnStart();

        Windows[0].Title = $"SINERGIA DT Operaciones CAM Camagüey v{Microsoft.Maui.ApplicationModel.AppInfo.Current.VersionString}";
    }
}
