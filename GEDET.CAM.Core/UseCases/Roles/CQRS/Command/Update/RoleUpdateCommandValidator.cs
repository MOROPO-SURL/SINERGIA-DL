using FluentValidation;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Update;

internal class RoleUpdateCommandValidator : AbstractValidator<RoleUpdateCommand>
{
    public RoleUpdateCommandValidator()
    {
    }
}
