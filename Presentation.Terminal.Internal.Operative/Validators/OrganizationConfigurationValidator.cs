using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Organization;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class OrganizationConfigurationValidator : AbstractValidator<OrganizationConfigurationPageModel>
{
    public OrganizationConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Nombre");

        RuleFor(model => model.Kind)
            .NotNull()
            .WithName("Tipo");

        RuleFor(model => model.About)
            .MaximumLength(2048)
            .WithName("Acerca de");
    }
}