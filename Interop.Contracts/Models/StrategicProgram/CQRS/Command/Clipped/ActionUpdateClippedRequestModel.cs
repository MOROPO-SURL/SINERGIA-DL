using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;

public record ActionUpdateClippedRequestModel(
    Guid Id, 
    string Title, 
    int Priority, 
    IEnumerable<ActionIndicatorCreateClippedRequestModel> InIndicators,
    IEnumerable<ActionIndicatorUpdateClippedRequestModel> PatchIndicators,
    IEnumerable<ActionIndicatorDetailDtoModel> OutIndicators,
    string? Description = null);