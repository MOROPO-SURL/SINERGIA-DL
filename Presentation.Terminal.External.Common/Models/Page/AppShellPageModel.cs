using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page;

public sealed class AppShellPageModel : Abstractions.AbstractContextPageModel
{
    public AppShellPageModel(OrganizationDetailDtoModel organization, PersonBasicDtoModel representative, Guid? developmentProfileId) : base(organization, representative, developmentProfileId)
    {
    }
}