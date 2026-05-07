using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Update;

public record FullUserUpdateCommand(string Id, string Name, bool IsEnabled, bool HasFullAccess, bool IsPasswordChangeRequired, string? LastName = null, Guid[]? Roles = null) : IUpdateCommand<string, DTOs.UserDetailDto>;