using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Common.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Validators;

public sealed class PostalAddressConfigurationValidator : AbstractValidator<PostalAddressConfigurationPageModel>
{
    public PostalAddressConfigurationValidator()
    {
        RuleFor(model => model.Street)
            .NotEmpty()
            .WithName("Calles");

        RuleFor(model => model.Name)
            .MaximumLength(60)
            .WithName("Nombre");
    }
}
