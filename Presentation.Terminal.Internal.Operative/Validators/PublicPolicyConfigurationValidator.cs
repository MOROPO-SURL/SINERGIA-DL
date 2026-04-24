using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.PublicPolicy;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class PublicPolicyConfigurationValidator : AbstractValidator<PublicPolicyConfigurationPageModel>
{
    public PublicPolicyConfigurationValidator()
    {
        RuleFor(model => model.Title)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Título");

        RuleFor(model => model.Description)
            .MaximumLength(2048)
            .WithName("Descripción");
    }
}
