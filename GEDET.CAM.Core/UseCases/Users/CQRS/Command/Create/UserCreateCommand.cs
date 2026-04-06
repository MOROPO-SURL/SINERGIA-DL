using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Create;
using MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Create;

public record UserCreateCommand(string Id, string Name, string Password, bool IsEnabled, bool IsPasswordChangeRequired, string? LastName = null, Guid[]? Roles = null) : ICreateCommand<UserDetailDto>;