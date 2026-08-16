using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

public sealed class StrategicProjectIndicatorChangeConfigurationValidator : AbstractValidator<IndicatorChangeConfigurationPageModel>
{
    public StrategicProjectIndicatorChangeConfigurationValidator()
    {
        RuleFor(model => model.Context)
            .MaximumLength(512)
            .WithName("Descrición");
    }
}