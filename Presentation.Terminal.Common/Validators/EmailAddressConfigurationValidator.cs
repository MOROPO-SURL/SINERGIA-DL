using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Common.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Validators;

public sealed class EmailAddressConfigurationValidator : AbstractValidator<EmailAddressConfigurationPageModel>
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
