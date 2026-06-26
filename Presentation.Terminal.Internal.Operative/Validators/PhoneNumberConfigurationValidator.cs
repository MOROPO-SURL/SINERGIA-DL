using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Common.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class PhoneNumberConfigurationValidator : AbstractValidator<PhoneNumberConfigurationPageModel>
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
