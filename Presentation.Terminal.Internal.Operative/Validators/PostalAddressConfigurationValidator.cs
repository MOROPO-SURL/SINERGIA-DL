using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Common.Configuration;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class PostalAddressConfigurationValidator : AbstractValidator<PostalAddressConfigurationPageModel>
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
