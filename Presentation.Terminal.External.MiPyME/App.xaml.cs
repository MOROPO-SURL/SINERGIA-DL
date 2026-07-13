namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new UI.Pages.MainPage());
    }

    protected override void OnStart()
    {
        base.OnStart();

        FFImageLoading.ImageService.Instance.Configuration.DiskCacheDuration = TimeSpan.MaxValue;

        Windows[0].Title = $"SINERGIA-DL MiPyMEs CAM Camagüey v{AppInfo.Current.VersionString}";
    }
}
