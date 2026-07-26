using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.SocialSupportDemand.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

public sealed class SocialSupportDemandLocationConfigurationValidator : AbstractValidator<LocationConfigurationPageModel>
{
    public SocialSupportDemandLocationConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(512)
            .WithName("Nombre");

        RuleFor(model => model.PostalAddressStreet)
            .NotEmpty()
            .WithName("Calles");

        RuleFor(model => model.LatitudeCoordinate)
            .NotEmpty()
            .NotNull()
            .WithName("Latitud");

        RuleFor(model => model.LongitudeCoordinate)
            .NotEmpty()
            .NotNull()
            .WithName("Longitud");

        RuleFor(model => model.Description)
            .MaximumLength(2048)
            .WithName("Descripción");
    }
}
