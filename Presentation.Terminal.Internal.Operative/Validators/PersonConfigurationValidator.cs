using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Person;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class PersonConfigurationValidator : AbstractValidator<PersonConfigurationPageModel>
{
    public PersonConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Nombre");

        RuleFor(model => model.LastName)
            .MaximumLength(360)
            .WithName("Apellidos");

        RuleFor(model => model.Alias)
            .MaximumLength(240);

        RuleFor(model => model.About)
            .MaximumLength(2048)
            .WithName("Acerca de");
    }
}