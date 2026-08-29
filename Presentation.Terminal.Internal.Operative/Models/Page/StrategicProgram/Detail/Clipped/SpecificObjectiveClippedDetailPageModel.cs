using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Detail.Clipped;

public sealed class SpecificObjectiveClippedDetailPageModel : AbstractDetailEntityPageModel<SpecificObjectiveDetailDtoModel>
{
    public SpecificObjectiveClippedDetailPageModel(SpecificObjectiveDetailDtoModel model) : base(model, null)
    {
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(SpecificObjectiveDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}