using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Detail.Clipped;

public sealed class SpecificObjectiveProjectClippedDetailPageModel : AbstractDetailEntityPageModel<SpecificObjectiveProjectDetailDtoModel>
{
    public SpecificObjectiveProjectClippedDetailPageModel(SpecificObjectiveProjectDetailDtoModel model) : base(model, null)
    {
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(SpecificObjectiveProjectDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}
