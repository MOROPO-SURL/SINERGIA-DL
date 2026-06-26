using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Detail;

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