using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Detail;

public sealed class StrategicLineSpecificObjectiveDetailPageModel : AbstractDetailEntityPageModel<SpecificObjectiveDetailDtoModel>
{
    public StrategicLineSpecificObjectiveDetailPageModel(SpecificObjectiveDetailDtoModel model) : base(model, null)
    {
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(SpecificObjectiveDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}