using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Location.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Validators;

public sealed class LocationConfigurationValidator : AbstractValidator<LocationConfigurationPageModel>
{
    public LocationConfigurationValidator()
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
