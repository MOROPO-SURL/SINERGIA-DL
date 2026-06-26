using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.UnitMeasurement;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class UnitMeasurementConfigurationValidator: AbstractValidator<UnitMeasurementConfigurationPageModel>
{
    public UnitMeasurementConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Nombre");

        RuleFor(model => model.Symbol)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Símbolo");
    }
}
