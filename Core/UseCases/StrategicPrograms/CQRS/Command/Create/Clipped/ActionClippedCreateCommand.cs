namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Clipped;

public record ActionClippedCreateCommand(
    Guid Id, 
    string Title, 
    int Priority,
    IEnumerable<ActionIndicatorClippedCreateCommand> Indicators,
    string? Description = null);