using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager.Adapters;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;

public static class MauiAppBuilderExtension
{
    public static MauiAppBuilder UsePresentationCommonDefaults(this MauiAppBuilder self)
    {
        self.Services
            .AddSingleton<ISessionManagerPort, DefaultSessionManagerPortAdapter>()
            .AddSingleton<ISettingManagerPort, DefaultSettingManagerPortAdapter>();

        return self;
    }
}
