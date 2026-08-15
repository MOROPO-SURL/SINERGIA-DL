using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Shells;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Ports.Adapter.Helper;

internal sealed class CurrentOrganizationDetailDtoModelBindingHelperPortAdapter : IAppShellContextBindingHelperPort
{
    public AppShellPageModel GetCurrent()
    {
        return (AppShellPageModel)((AppShell)Application.Current!.MainPage!).BindingContext;
    }
}
