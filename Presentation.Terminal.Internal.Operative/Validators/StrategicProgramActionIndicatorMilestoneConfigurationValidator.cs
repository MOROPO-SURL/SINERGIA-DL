using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

public sealed class StrategicProgramActionIndicatorMilestoneConfigurationValidator : AbstractValidator<MilestoneClippedConfigurationPageModel>
{
    public StrategicProgramActionIndicatorMilestoneConfigurationValidator()
    {
        RuleFor(model => model.Amount)
            .GreaterThan(0)
            .WithName("Cantidad");

        RuleFor(model => model.Description)
            .MaximumLength(512)
            .WithName("Descripción");
    }
}