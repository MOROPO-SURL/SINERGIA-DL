using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

public record DeepStrategicLineViewModel(StrategicLineDetailDtoModel Line, IEnumerable<DeepStrategicProgramViewModel> Programs);