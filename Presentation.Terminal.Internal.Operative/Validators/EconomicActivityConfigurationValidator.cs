using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.EconomicActivity;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class EconomicActivityConfigurationValidator : AbstractValidator<EconomicActivityConfigurationPageModel>
{
    public EconomicActivityConfigurationValidator()
    {
        RuleFor(model => model.Id)
            .GreaterThan(0)
            .WithName("Número");

        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(2048)
            .WithName("Nombre");
    }
}
