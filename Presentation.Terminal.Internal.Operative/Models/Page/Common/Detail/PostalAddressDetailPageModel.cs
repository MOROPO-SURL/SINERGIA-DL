using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Common.Detail;

public sealed class PostalAddressDetailPageModel : AbstractDetailEntityPageModel<PostalAddressDetailDtoModel>
{
    public PostalAddressDetailPageModel(PostalAddressDetailDtoModel model) : base(model, null)
    {
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(PostalAddressDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}