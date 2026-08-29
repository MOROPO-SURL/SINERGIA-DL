using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.CQRS.Command.Remove;

public record UserRemoveCommand(string Id) : IRemoveCommand<string>;
