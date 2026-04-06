using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Update;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Update;

public record FullUserUpdateCommand(string Id, string Name, string? LastName = null, Guid[]? Roles = null) : IUpdateCommand<string, DTOs.UserDetailDto>;