using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page.DevelopmentActorProfile;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Validators;

public sealed class LegalOwnedPDLDevelopmentActorProfileConfigurationValidator : AbstractValidator<LegalOwnedPDLDevelopmentActorProfileConfigurationPageModel>
{
    public LegalOwnedPDLDevelopmentActorProfileConfigurationValidator()
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

        RuleFor(model => model.Holder)
            .NotNull()
            .WithName("Titular");

        RuleFor(model => model.Modality)
            .NotNull()
            .WithName("Modalidad");

        RuleFor(model => model.About)
            .MaximumLength(2048)
            .WithName("Acerca de");
    }
}
