using FluentValidation;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Create;

internal class RoleCreateCommandValidator : AbstractValidator<RoleCreateCommand>
{
    public RoleCreateCommandValidator()
    {

    }
}