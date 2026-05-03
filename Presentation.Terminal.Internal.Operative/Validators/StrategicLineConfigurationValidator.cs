using FluentValidation;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class StrategicLineConfigurationValidator : AbstractValidator<Models.Page.StrategicLine.Configuration.StrategicLineConfigurationPageModel>
{
    public StrategicLineConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Nombre");

        RuleFor(model => model.Axe)
            .NotNull()
            .WithName("Eje estratégico");

        RuleFor(model => model.Description)
            .MaximumLength(2048)
            .WithName("Descripción");
    }
}