using FluentValidation;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Validators;

internal sealed class UserAuthenticationValidator : AbstractValidator<Models.Page.UserAuthenticationPageModel>
{
    public UserAuthenticationValidator()
    {
        RuleFor(model => model.UserName)
            .NotEmpty()
            .WithName("Usuario");

        RuleFor(model => model.Password)
            .NotEmpty()
            .WithName("Contraseña");
    }
}
