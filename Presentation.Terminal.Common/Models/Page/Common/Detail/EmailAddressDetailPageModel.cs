using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Common.Detail;

public sealed class EmailAddressDetailPageModel : AbstractDetailEntityPageModel<EmailAddressDetailDtoModel>
{
    public EmailAddressDetailPageModel(EmailAddressDetailDtoModel model) : base(model, null)
    {
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(EmailAddressDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}