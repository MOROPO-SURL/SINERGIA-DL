using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Ports.Helper;

public interface ICurrentOrganizationDetailDtoModelBindingHelperPort
{
    OrganizationDetailDtoModel GetCurrent();
}
