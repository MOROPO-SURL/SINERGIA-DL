using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.UI.Shells;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Ports.Adapter.Helper;

internal sealed class AppShellContextBindingHelperPortAdapter : IAppShellContextBindingHelperPort
{
    public AppShellPageModel GetCurrent()
    {
        return (AppShellPageModel)((AppShell)Application.Current!.MainPage!).BindingContext;
    }
}
