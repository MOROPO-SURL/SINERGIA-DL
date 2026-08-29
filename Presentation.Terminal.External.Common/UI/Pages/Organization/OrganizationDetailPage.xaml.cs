using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Organization;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page.Organization;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Ports.Helper;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.UI.Pages.Organization;

public partial class OrganizationDetailPage : BaseDetailEntityPage<OrganizationDetailDtoModel, OrganizationDetailPageModel>, IDetailItemPageModelPresenter<OrganizationDetailDtoModel>
{
    public OrganizationDetailPage() : base(new OrganizationDetailPageModel(IPlatformApplication.Current!.Services.GetRequiredService<IAppShellContextBindingHelperPort>().GetCurrent().Organization))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemModifyUserInterfaceAsync(OrganizationDetailDtoModel model, Action<OrganizationDetailDtoModel> configurationSuccessCallbackAction)
    {
        await this.NavigationPushPageAsync(new OrganizationConfigurationPage(new OrganizationConfigurationPageModel(model, configurationSuccessCallbackAction)));
    }
}