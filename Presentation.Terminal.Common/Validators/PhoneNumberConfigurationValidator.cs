using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Common.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Validators;

public sealed class PhoneNumberConfigurationValidator : AbstractValidator<PhoneNumberConfigurationPageModel>
{
    public PhoneNumberConfigurationValidator()
    {
        RuleFor(model => model.Value)
            .NotEmpty()
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Formato incorrecto.")
            .WithName("Número");

        RuleFor(model => model.Name)
            .MaximumLength(60)
            .WithName("Nombre");
    }
}
