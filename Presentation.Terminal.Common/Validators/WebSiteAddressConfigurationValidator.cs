using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Common.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Validators;

public sealed class WebSiteAddressConfigurationValidator : AbstractValidator<WebSiteAddressConfigurationPageModel>
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
