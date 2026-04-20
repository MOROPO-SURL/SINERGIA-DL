using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Update;

public record MacroprogramUpdateCommand(Guid Id, string Title, string? Description, int Index) : IUpdateCommand<Guid, DTOs.MacroprogramDetailDto>;

