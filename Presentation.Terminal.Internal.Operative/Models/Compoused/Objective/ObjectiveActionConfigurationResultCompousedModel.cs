using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Compoused.Objective;

public record ObjectiveActionConfigurationResultCompousedModel(ObjectiveActionDetailDtoModel Detail, ObjectiveActionUpdateRequestModel UpdateRequest);

