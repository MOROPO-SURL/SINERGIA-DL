using FluentValidation;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class StrategicProjectIdeaConfigurationValidator : AbstractValidator<Models.Page.StrategicProjectIdea.Configuration.StrategicProjectIdeaConfigurationPageModel>
{
    public StrategicProjectIdeaConfigurationValidator()
    {
        RuleFor(model => model.Title)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Título");

        RuleFor(model => model.Program)
            .NotNull()
            .WithName("Programa");

        RuleFor(model => model.Description)
            .MaximumLength(2048)
            .WithName("Descripción");
    }
}