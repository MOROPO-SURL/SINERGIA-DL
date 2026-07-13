using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Feature;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class FeatureConfigurationValidator : AbstractValidator<FeatureConfigurationPageModel>
{
    public FeatureConfigurationValidator()
    {
        RuleFor(model => model.Kind)
            .NotNull()
            .WithName("Tipo");

        RuleFor(model => model.Description)
            .NotEmpty()
            .MaximumLength(51200)
            .WithName("Descripción");
    }
}
