using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page.SocialSupportDemand.Detail;

public sealed class LocationDetailPageModel : AbstractDetailEntityPageModel<LocationDetailDtoModel>
{
    public LocationDetailPageModel(LocationDetailDtoModel model) : base(model, null)
    {
    }

    protected override Task PerformRemotionAsync(LocationDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}
