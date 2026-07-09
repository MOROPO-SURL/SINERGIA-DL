using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Factories;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Validators;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page;

public class SettingPageModel : BasePageModel, Interfaces.IValidableConfigurationPageModel
{
    public static string ProxyServerAddressValidableProperty => nameof(ProxyServerAddress);
    public static string ProxyUsernameValidableProperty => nameof(ProxyUsername);
    public static string ProxyPasswordValidableProperty => nameof(ProxyPassword);

    private bool useProxyServer;
    private string? proxyServerAddress;
    private bool useProxyAuthentication;
    private string? proxyUsername;
    private string? proxyPassword;
    private FluentValidation.Results.ValidationResult? validationResult;

    private readonly Action validationCallbackAction;

    public SettingPageModel(Action applySuccessCallbackAction, Action validationCallbackAction)
    {
        this.validationCallbackAction = validationCallbackAction;

        ISettingManagerPort settingManager = IPlatformApplication.Current!.Services.GetRequiredService<ISettingManagerPort>();

        useProxyServer = settingManager.UseProxyServer;
        proxyServerAddress = settingManager.ProxyServerAddress;
        useProxyAuthentication = settingManager.UseProxyAuthentication;
        proxyUsername = settingManager.ProxyUsername;
        proxyPassword = settingManager.ProxyPassword;

        ApplyChangesCommand = new Command(
            execute: () =>
            {
                SettingValidator validator = new();

                ValidationResult = null;
                ValidationResult = validator.Validate(this);

                if (!ValidationResult.IsValid) return;

                settingManager.UseProxyServer = useProxyServer;
                settingManager.ProxyServerAddress = proxyServerAddress;
                settingManager.UseProxyAuthentication = useProxyAuthentication;
                settingManager.ProxyUsername = proxyUsername;
                settingManager.ProxyPassword = proxyPassword;

                FFImageLoading.ImageService.Instance.Configuration.HttpClient = new HttpClient(HttpClientHandlerFactory.Build());

                applySuccessCallbackAction.Invoke();
            }
        );
    }

    public System.Windows.Input.ICommand ApplyChangesCommand { get; private set; }

    public bool UseProxyServer { get => useProxyServer; set => SetProperty(ref useProxyServer, value); }

    public string? ProxyServerAddress { get => proxyServerAddress; set => SetProperty(ref proxyServerAddress, value); }

    public bool UseProxyAuthentication { get => useProxyAuthentication; set => SetProperty(ref useProxyAuthentication, value); }

    public string? ProxyUsername { get => proxyUsername; set => SetProperty(ref proxyUsername, value); }

    public string? ProxyPassword { get => proxyPassword; set => SetProperty(ref proxyPassword, value); }

    public FluentValidation.Results.ValidationResult? ValidationResult { get => validationResult; set => SetProperty(ref validationResult, value, validationCallbackAction); }
}