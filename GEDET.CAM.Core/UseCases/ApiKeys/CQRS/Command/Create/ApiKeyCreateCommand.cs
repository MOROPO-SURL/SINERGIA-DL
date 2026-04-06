using MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Create;

namespace MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.CQRS.Command.Create;

// TODO Generate Token value!!!
public record ApiKeyCreateCommand(string Name, bool IsEnabled, DateTime ExpireAt, string[] Permissions, string? Host) : ICreateCommand<ApiKeyDetailDto>;