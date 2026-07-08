using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page;

public sealed class AppShellPageModel : Abstractions.AbstractContextPageModel
{
    public AppShellPageModel(OrganizationDetailDtoModel organization, PersonBasicDtoModel representative) : base(organization, representative)
    {
    }
}
