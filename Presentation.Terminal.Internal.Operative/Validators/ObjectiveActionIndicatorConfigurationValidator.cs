using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class ObjectiveActionIndicatorConfigurationValidator : AbstractValidator<ObjectiveIndicatorConfigurationPageModel>
{
    public ObjectiveActionIndicatorConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Nombre");

        RuleFor(model => model.Alias)
            .MaximumLength(360)
            .WithName("Alias");

        RuleFor(model => model.UnitMeasurement)
            .NotNull()
            .WithName("Unidad de medida");

        RuleFor(model => model.Milestones)
            .NotEmpty()
            .WithName("Metas");
    }
}
