using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Compoused.StrategicProgram;

public record IndicatorConfigurationResultCompousedModel(ActionIndicatorDetailDtoModel Detail, ActionIndicatorUpdateClippedRequestModel UpdateRequest);