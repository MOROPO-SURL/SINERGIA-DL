using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class StrategicProgramActionIndicatorConfigurationValidator : AbstractValidator<IndicatorClippedConfigurationPageModel>
{
    public StrategicProgramActionIndicatorConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Nombre");

        RuleFor(model => model.Alias)
            .MaximumLength(360)
            .WithName("Alias");

        RuleFor(model => model.UnitMeasurement)
            .NotNull()
            .WithName("Unidad de medida");
    }
}
