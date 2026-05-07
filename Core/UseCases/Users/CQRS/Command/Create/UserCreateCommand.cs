using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Create;

public record UserCreateCommand(string Id, string Name, string Password, bool IsEnabled, bool IsPasswordChangeRequired, bool HasFullAccess, string? LastName = null, Guid[]? Roles = null) : ICreateCommand<UserDetailDto>;