using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Configuration;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class ObjectiveActionConfigurationValidator : AbstractValidator<ObjectiveActionConfigurationPageModel>
{
    private readonly ObjectiveConfigurationPageModel objectiveConfigurationPageModel;

    public ObjectiveActionConfigurationValidator(ObjectiveConfigurationPageModel objectiveConfigurationPageModel)
    {
        this.objectiveConfigurationPageModel = objectiveConfigurationPageModel;

        RuleFor(model => model.Index)
            .Must(HasValidIndex).WithMessage("Ya existen retos con el índice especificado")
            .WithName("Índice");

        RuleFor(model => model.Title)
            .NotEmpty()
            .MaximumLength(360)
            .WithName("Título");

        RuleFor(model => model.Description)
            .MaximumLength(2048)
            .WithName("Descripción");
    }

    private bool HasValidIndex(ObjectiveActionConfigurationPageModel model, int value)
    {
        if (model.Id != null)
        {
            ObjectiveActionDetailDtoModel? target = objectiveConfigurationPageModel.Actions.FirstOrDefault(item => item.Index == model.Index);

            if (target == null) return true;

            return model.Id == target.Id;
        }

        return !objectiveConfigurationPageModel.Actions.Any(item => item.Index == value);
    }
}