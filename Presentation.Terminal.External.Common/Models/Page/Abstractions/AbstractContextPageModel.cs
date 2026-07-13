using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page.Abstractions;

public abstract class AbstractContextPageModel : BasePageModel
{
    private OrganizationDetailDtoModel organization = null!;
    private PersonBasicDtoModel representative = null!;

    protected AbstractContextPageModel(OrganizationDetailDtoModel organization, PersonBasicDtoModel representative)
    {
        Organization = organization;
        Representative = representative;
    }

    public OrganizationDetailDtoModel Organization { get => organization; set => SetProperty(ref organization, value); }

    public PersonBasicDtoModel Representative { get => representative; set => SetProperty(ref representative, value); }
}
