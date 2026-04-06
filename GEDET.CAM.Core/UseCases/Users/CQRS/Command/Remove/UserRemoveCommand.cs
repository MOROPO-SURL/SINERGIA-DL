using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Remove;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Remove;

public record UserRemoveCommand(string Id) : IRemoveCommand<string>;
