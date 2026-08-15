using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

public sealed class ObjectiveActionIndicatorChangeConfigurationValidator : AbstractValidator<IndicatorChangeConfigurationPageModel>
{
    public ObjectiveActionIndicatorChangeConfigurationValidator()
    {
        RuleFor(model => model.Context)
            .MaximumLength(512)
            .WithName("Descrición");
    }
}