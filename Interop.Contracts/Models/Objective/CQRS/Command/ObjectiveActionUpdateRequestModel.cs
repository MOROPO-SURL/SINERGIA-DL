using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Command;

public record ObjectiveActionUpdateRequestModel(
    Guid Id, 
    int Index, 
    string Title,
    IEnumerable<ObjectiveActionIndicatorCreateRequestModel> InIndicators,
    IEnumerable<ObjectiveActionIndicatorUpdateRequestModel> PatchIndicators,
    IEnumerable<ObjectiveActionIndicatorDetailDtoModel> OutIndicators,
    string? Description = null);