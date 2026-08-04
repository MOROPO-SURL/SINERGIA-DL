using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.DevelopmentActorProfile;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Validators;

public sealed class DevelopmentActorProfileConfigurationValidator : AbstractValidator<DevelopmentActorProfileConfigurationPageModel>
{
    public DevelopmentActorProfileConfigurationValidator()
    {
        RuleFor(model => model.MainEconomicActivity)
            .NotNull()
            .WithName("Actividad económica principal");

        RuleFor(model => model.MainLocation)
            .NotNull()
            .WithName("Localización de domicilio social");

        RuleFor(model => model.FiscalIdentificationCode)
            .NotEmpty()
            .Matches("^[0-9]+$")
            .WithName("NIT");

        RuleFor(model => model.BornAt)
            .LessThan(DateTime.Now.AddDays(1))
            .WithName("Fecha de fundación");

        RuleFor(model => model.OrganizationPartners)
            .Must((model, field) => field.Any() || model.PersonPartners.Any())
            .WithName("Socios fiscales")
            .WithMessage("Debe definir al menos un socio, ya sea fiscal o natural");

        RuleFor(model => model.PersonPartners)
            .Must((model, field) => field.Any() || model.OrganizationPartners.Any())
            .WithName("Socios naturales")
            .WithMessage("Debe definir al menos un socio, ya sea fiscal o natural");

        RuleFor(model => model.About)
            .MaximumLength(2048)
            .WithName("Acerca de");
    }
}
