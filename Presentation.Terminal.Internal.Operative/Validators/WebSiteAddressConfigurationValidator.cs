using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Common.Configuration;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class WebSiteAddressConfigurationValidator : AbstractValidator<WebSiteAddressConfigurationPageModel>
{
    public WebSiteAddressConfigurationValidator()
    {
        RuleFor(model => model.Url)
            .NotEmpty()
            .WithName("Dirección");

        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(60)
            .WithName("Nombre");
    }
}
