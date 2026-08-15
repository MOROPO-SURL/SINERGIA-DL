using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.SocialSupportDemand.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

public sealed class SocialSupportDemandConfigurationValidator : AbstractValidator<SocialSupportDemandConfigurationPageModel>
{
    public SocialSupportDemandConfigurationValidator()
    {
        RuleFor(model => model.Title)
            .NotEmpty()
            .MaximumLength(512)
            .WithName("Título");

        RuleFor(model => model.Description)
            .MaximumLength(2048)
            .WithName("Descripción");

        RuleFor(model => model.Locations)
            .NotEmpty()
            .WithName("Localizaciones");

        RuleFor(model => model.EndAt)
            .Must((model, property) => !(model.HasStartAt && model.HasEndAt && model.EndAt.Date < model.StartAt.Date))
            .WithMessage("La fecha de fin debe ser superior a la de inicio");
    }
}
