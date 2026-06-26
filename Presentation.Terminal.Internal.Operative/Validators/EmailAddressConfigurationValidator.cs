using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Common.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class EmailAddressConfigurationValidator : AbstractValidator<EmailAddressConfigurationPageModel>
{
    public EmailAddressConfigurationValidator()
    {
        RuleFor(model => model.Value)
            .NotEmpty()
            .EmailAddress()
            .WithName("Dirección");

        RuleFor(model => model.Name)
            .MaximumLength(60)
            .WithName("Nombre");
    }
}
