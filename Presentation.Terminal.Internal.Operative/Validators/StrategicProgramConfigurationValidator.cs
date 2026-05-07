using FluentValidation;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class StrategicProgramConfigurationValidator : AbstractValidator<Models.Page.StrategicProgram.Configuration.StrategicProgramConfigurationPageModel>
{
    public StrategicProgramConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Nombre");

        RuleFor(model => model.Line)
            .NotNull()
            .WithName("Línea estratégica");

        RuleFor(model => model.Coordinator)
            .NotNull()
            .WithName("Coordinador");

        RuleFor(model => model.Description)
            .MaximumLength(2048)
            .WithName("Descripción");
    }
}