using FluentValidation;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class StrategicProjectConfigurationValidator : AbstractValidator<Models.Page.StrategicProject.Configuration.StrategicProjectConfigurationPageModel>
{
    public StrategicProjectConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Nombre");

        RuleFor(model => model.Kind)
            .NotNull()
            .WithName("Tipo");

        RuleFor(model => model.Program)
            .NotNull()
            .WithName("Programa");

        RuleFor(model => model.Objective)
            .NotEmpty()
            .MaximumLength(1024)
            .WithName("Objetivo");

        RuleFor(model => model.Description)
            .MaximumLength(2048)
            .WithName("Descripción");
    }
}