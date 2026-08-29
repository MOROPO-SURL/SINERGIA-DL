using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page;

public sealed class DashboardPageModel : Common.Models.Page.Abstractions.AbstractContextPageModel
{
    public DashboardPageModel(OrganizationDetailDtoModel organization, PersonBasicDtoModel representative) : base(organization, representative, null)
    {
    }

    public void LoadState()
    {
        DevelopmentProfileId = ((Common.Models.Page.AppShellPageModel)Shell.Current!.BindingContext).DevelopmentProfileId;
    }
}
