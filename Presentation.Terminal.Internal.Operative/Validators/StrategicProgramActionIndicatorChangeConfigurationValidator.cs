using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

public sealed class StrategicProgramActionIndicatorChangeConfigurationValidator : AbstractValidator<IndicatorChangeConfigurationPageModel>
{
    public StrategicProgramActionIndicatorChangeConfigurationValidator()
    {
        RuleFor(model => model.Context)
            .MaximumLength(512)
            .WithName("Descrición");
    }
}
