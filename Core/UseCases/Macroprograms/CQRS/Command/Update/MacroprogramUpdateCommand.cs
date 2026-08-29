using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.CQRS.Command.Update;

public record MacroprogramUpdateCommand(Guid Id, string Title, string? Description, int Index) : IUpdateCommand<Guid, DTOs.MacroprogramDetailDto>;

