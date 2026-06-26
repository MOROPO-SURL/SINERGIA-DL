using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Common.Detail;

public sealed class PhoneNumberDetailPageModel : AbstractDetailEntityPageModel<PhoneNumberDetailDtoModel>
{
    public PhoneNumberDetailPageModel(PhoneNumberDetailDtoModel model) : base(model, null)
    {
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(PhoneNumberDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}