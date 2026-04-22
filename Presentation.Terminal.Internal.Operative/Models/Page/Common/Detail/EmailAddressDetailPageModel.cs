using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Common.Detail;

public sealed class EmailAddressDetailPageModel : AbstractDetailEntityPageModel<EmailAddressDetailDtoModel>
{
    public EmailAddressDetailPageModel(EmailAddressDetailDtoModel model) : base(model, null)
    {
    }

    protected override Task PerformRemotionAsync(EmailAddressDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}
