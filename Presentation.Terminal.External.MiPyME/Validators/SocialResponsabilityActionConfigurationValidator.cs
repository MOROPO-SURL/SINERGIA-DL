using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.SocialResponsabilityAction;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Validators;

public sealed class SocialResponsabilityActionConfigurationValidator : AbstractValidator<SocialResponsabilityActionConfigurationPageModel>
{
    public SocialResponsabilityActionConfigurationValidator()
    {
        RuleFor(model => model.Title)
            .NotEmpty()
            .MaximumLength(512)
            .WithName("Título");

        RuleFor(model => model.Description)
            .MaximumLength(2048)
            .WithName("Descripción");

        RuleFor(model => model.Locations)
            .NotEmpty()
            .WithName("Localizaciones");

        RuleFor(model => model.At)
            .LessThanOrEqualTo(model => DateTime.Now)
            .WithName("Fecha");
    }
}
