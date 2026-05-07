using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.View;

public record DeepStrategicLineViewModel(StrategicLineDetailDtoModel Line, IEnumerable<DeepStrategicProgramViewModel> Programs);