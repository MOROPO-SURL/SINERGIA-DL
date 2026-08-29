using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update.Clipped;

public record ActionClippedUpdateCommand(
    Guid Id, 
    string Title, 
    int Priority,
    IEnumerable<ActionIndicatorClippedCreateCommand> InIndicators,
    IEnumerable<ActionIndicatorClippedUpdateCommand> PatchIndicators,
    IEnumerable<ActionIndicatorClippedDetailDto> OutIndicators,
    string? Description = null);