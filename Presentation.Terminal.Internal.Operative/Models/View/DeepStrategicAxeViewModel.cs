using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.View;

public record DeepStrategicAxeViewModel(StrategicAxeDetailDtoModel Axe, IEnumerable<DeepStrategicLineViewModel> Lines);
