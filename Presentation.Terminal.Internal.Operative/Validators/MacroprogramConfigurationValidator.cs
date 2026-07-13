using FluentValidation;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;


/* Cambio no fusionado mediante combinación del proyecto 'Presentation.Terminal.Internal.Operative (net8.0-android)'
Antes:
internal sealed class MacroprogramConfigurationValidator : AbstractValidator<Models.Page.Macroprogram.Configuration.MacroprogramConfigurationPageModel>
Después:
internal sealed class MacroprogramConfigurationValidator : AbstractValidator<MacroprogramConfigurationPageModel>
*/
internal sealed class MacroprogramConfigurationValidator : AbstractValidator<Models.Page.Macroprogram.MacroprogramConfigurationPageModel>
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