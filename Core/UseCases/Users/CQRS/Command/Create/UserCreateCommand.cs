using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.CQRS.Command.Create;

public record UserCreateCommand(string Id, string Name, string Password, bool IsEnabled, bool IsPasswordChangeRequired, bool HasFullAccess, string? LastName = null, Guid[]? Roles = null) : ICreateCommand<UserDetailDto>;