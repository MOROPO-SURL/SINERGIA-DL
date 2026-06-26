using FluentValidation;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class StrategicLineConfigurationValidator : AbstractValidator<Models.Page.StrategicLine.Configuration.StrategicLineConfigurationPageModel>
{
    public StrategicLineConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Nombre");

        RuleFor(model => model.Coordinator)
            .NotNull()
            .WithName("Coordinador");

        RuleFor(model => model.Objective)
            .NotEmpty()
            .MaximumLength(1024)
            .WithName("Objetivo");

        RuleFor(model => model.Description)
            .MaximumLength(2048)
            .WithName("Descripción");
    }
}