using FluentValidation;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Command.Update;

internal class RoleUpdateCommandValidator : AbstractValidator<RoleUpdateCommand>
{
    public RoleUpdateCommandValidator()
    {
    }
}
