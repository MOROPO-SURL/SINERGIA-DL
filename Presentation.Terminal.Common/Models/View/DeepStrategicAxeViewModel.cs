using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.View;

public record DeepStrategicAxeViewModel(StrategicAxeDetailDtoModel Axe, IEnumerable<DeepStrategicLineViewModel> Lines);