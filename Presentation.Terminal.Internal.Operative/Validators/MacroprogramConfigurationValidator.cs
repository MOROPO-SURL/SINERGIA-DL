using FluentValidation;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class MacroprogramConfigurationValidator : AbstractValidator<Models.Page.Macroprogram.Configuration.MacroprogramConfigurationPageModel>
{
    public MacroprogramConfigurationValidator()
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