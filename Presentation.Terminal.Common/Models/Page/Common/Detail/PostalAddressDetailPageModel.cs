using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Common.Detail;

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