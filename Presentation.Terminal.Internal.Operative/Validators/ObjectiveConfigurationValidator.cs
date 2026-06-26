using FluentValidation;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;


/* Cambio no fusionado mediante combinación del proyecto 'Presentation.Terminal.Internal.Operative (net8.0-maccatalyst)'
Antes:
internal sealed class ObjectiveConfigurationValidator : AbstractValidator<Models.Page.Configuration.ObjectiveConfigurationPageModel>
Después:
internal sealed class ObjectiveConfigurationValidator : AbstractValidator<ObjectiveConfigurationPageModel>
*/
internal sealed class ObjectiveConfigurationValidator : AbstractValidator<Models.Page.Objective.Configuration.ObjectiveConfigurationPageModel>
{
    public ObjectiveConfigurationValidator()
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
