namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;

public interface ISettingManagerPort
{
    bool UseProxyServer { get; set; }

    string ProxyServerAddress { get; set; }

    bool UseProxyAuthentication { get; set; }

    string ProxyUsername { get; set; }

    string ProxyPassword { get; set; }
}
