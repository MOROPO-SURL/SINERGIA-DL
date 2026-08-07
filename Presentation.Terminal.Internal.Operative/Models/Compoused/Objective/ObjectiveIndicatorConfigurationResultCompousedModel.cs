using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Compoused.Objective;

public record ObjectiveIndicatorConfigurationResultCompousedModel(ObjectiveActionIndicatorDetailDtoModel Detail, ObjectiveActionIndicatorUpdateRequestModel UpdateRequest);
