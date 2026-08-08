using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Compoused.StrategicProject
{
    public record IndicatorProjectConfigurationResultCompousedModel(IndicatorDetailDtoModel Detail, IndicatorUpdateClippedRequestModel UpdateRequest);
}
