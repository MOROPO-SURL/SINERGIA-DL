using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.CQRS.Command.Update;

public record FullUserUpdateCommand(string Id, string Name, bool IsEnabled, bool HasFullAccess, bool IsPasswordChangeRequired, string? LastName = null, Guid[]? Roles = null) : IUpdateCommand<string, DTOs.UserDetailDto>;