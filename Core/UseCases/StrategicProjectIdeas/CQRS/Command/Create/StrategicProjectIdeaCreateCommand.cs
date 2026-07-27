using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.CQRS.Command.Create;

public record StrategicProjectIdeaCreateCommand(
    Guid Id, 
    string Title, 
    int Priority,
    bool IsEnabled,
    Guid ProgramId, 
    string? Description = null) : ICreateCommand<StrategicProjectIdeaDetailDto>;