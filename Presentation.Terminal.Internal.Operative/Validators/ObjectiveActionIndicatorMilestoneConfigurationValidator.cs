using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

public sealed class ObjectiveActionIndicatorMilestoneConfigurationValidator : AbstractValidator<ObjectiveMilestoneConfigurationPageModel>
{
    public ObjectiveActionIndicatorMilestoneConfigurationValidator()
    {
        RuleFor(model => model.Amount)
            .GreaterThan(0)
            .WithName("Cantidad");

        RuleFor(model => model.Description)
            .MaximumLength(512)
            .WithName("Descripción");
    }
}
