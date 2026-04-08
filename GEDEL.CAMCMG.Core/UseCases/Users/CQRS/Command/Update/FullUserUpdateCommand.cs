using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Update;

public record FullUserUpdateCommand(string Id, string Name, string? LastName = null, Guid[]? Roles = null) : IUpdateCommand<string, DTOs.UserDetailDto>;