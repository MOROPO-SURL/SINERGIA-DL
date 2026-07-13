using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class StrategicLineSpecificObjectiveConfigurationValidator : AbstractValidator<StrategicLineSpecificObjectiveConfigurationPageModel>
{
    private readonly StrategicLineConfigurationPageModel configurationPageModel;

    public StrategicLineSpecificObjectiveConfigurationValidator(StrategicLineConfigurationPageModel configurationPageModel)
    {
        this.configurationPageModel = configurationPageModel;

        RuleFor(model => model.Index)
            .Must(HasValidIndex).WithMessage("Ya existen retos con el índice especificado")
            .WithName("Índice");

        RuleFor(model => model.Content)
            .NotEmpty()
            .MaximumLength(2048)
            .WithName("Contenido");
    }

    private bool HasValidIndex(StrategicLineSpecificObjectiveConfigurationPageModel model, int value)
    {
        if (model.Id != null)
        {
            StrategicLineSpecificObjectiveDetailDtoModel? target = configurationPageModel.SpecificObjectives.FirstOrDefault(item => item.Index == model.Index);

            if (target == null) return true;

            return model.Id == target.Id;
        }

        return !configurationPageModel.SpecificObjectives.Any(item => item.Index == value);
    }
}
