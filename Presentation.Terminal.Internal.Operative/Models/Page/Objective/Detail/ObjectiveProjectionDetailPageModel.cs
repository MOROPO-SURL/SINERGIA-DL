using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Detail;

public sealed class ObjectiveProjectionDetailPageModel : AbstractDetailEntityPageModel<ObjectiveProjectionDetailDtoModel>
{
    public ObjectiveProjectionDetailPageModel(ObjectiveProjectionDetailDtoModel model) : base(model, null)
    {
    }

    protected override Task PerformRemotionAsync(ObjectiveProjectionDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}