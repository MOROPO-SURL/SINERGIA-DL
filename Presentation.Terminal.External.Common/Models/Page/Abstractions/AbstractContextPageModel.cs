using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page.Abstractions;

public abstract class AbstractContextPageModel : BasePageModel
{
    private OrganizationDetailDtoModel organization = null!;
    private PersonBasicDtoModel representative = null!;
    private Guid? developmentProfileId;

    protected AbstractContextPageModel(OrganizationDetailDtoModel organization, PersonBasicDtoModel representative, Guid? developmentProfileId)
    {
        Organization = organization;
        Representative = representative;
        DevelopmentProfileId = developmentProfileId;
    }

    public OrganizationDetailDtoModel Organization { get => organization; set => SetProperty(ref organization, value); }

    public PersonBasicDtoModel Representative { get => representative; set => SetProperty(ref representative, value); }

    public Guid? DevelopmentProfileId { get => developmentProfileId; set => SetProperty(ref developmentProfileId, value); }
}
