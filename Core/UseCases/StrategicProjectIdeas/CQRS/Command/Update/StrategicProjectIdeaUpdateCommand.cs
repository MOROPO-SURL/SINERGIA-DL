using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.CQRS.Command.Update;

public record StrategicProjectIdeaUpdateCommand(
    Guid Id, 
    string Title,
    int Priority, 
    bool IsEnabled,
    Guid ProgramId,
    string? Description = null) : IUpdateCommand<Guid, DTOs.StrategicProjectIdeaDetailDto>;