using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Detail;

public sealed class StrategicLineSpecificObjectiveDetailPageModel : AbstractDetailEntityPageModel<StrategicLineSpecificObjectiveDetailDtoModel>
{
    public StrategicLineSpecificObjectiveDetailPageModel(StrategicLineSpecificObjectiveDetailDtoModel model) : base(model, null)
    {
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(StrategicLineSpecificObjectiveDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}