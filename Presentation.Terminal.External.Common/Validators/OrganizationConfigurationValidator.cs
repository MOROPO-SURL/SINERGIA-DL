using FluentValidation;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Validators;

internal sealed class OrganizationConfigurationValidator : AbstractValidator<Models.Page.Organization.OrganizationConfigurationPageModel>
{
    public OrganizationConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Nombre");

        RuleFor(model => model.About)
            .MaximumLength(2048)
            .WithName("Acerca de");
    }
}