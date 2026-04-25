using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Detail;

public sealed class ObjectiveChallengeDetailPageModel : AbstractDetailEntityPageModel<ObjectiveChallengeDetailDtoModel>
{
    public ObjectiveChallengeDetailPageModel(ObjectiveChallengeDetailDtoModel model) : base(model, null)
    {
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(ObjectiveChallengeDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}