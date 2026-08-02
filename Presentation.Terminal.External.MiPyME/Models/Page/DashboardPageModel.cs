using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page;

public sealed class DashboardPageModel : AbstractContextPageModel
{
    private bool isDevelopmentActorProfileMissing;

    public DashboardPageModel(OrganizationDetailDtoModel organization, PersonBasicDtoModel representative) : base(organization, representative, null)
    {
    }

    public bool IsDevelopmentActorProfileMissing { get => isDevelopmentActorProfileMissing; set => SetProperty(ref isDevelopmentActorProfileMissing, value); }

    public void LoadState()
    {
        DevelopmentProfileId = ((Common.Models.Page.AppShellPageModel)Shell.Current!.BindingContext).DevelopmentProfileId;
    }
}