namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative;

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

        Windows[0].Title = $"SINERGIA-DL Operaciones CAM Camagüey v{AppInfo.Current.VersionString}";
    }
}
