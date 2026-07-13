using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class ObjectiveProjectionConfigurationValidator : AbstractValidator<ObjectiveProjectionConfigurationPageModel>
{
    private readonly ObjectiveConfigurationPageModel objectiveConfigurationPageModel;

    public ObjectiveProjectionConfigurationValidator(ObjectiveConfigurationPageModel objectiveConfigurationPageModel)
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

    private bool HasValidIndex(ObjectiveProjectionConfigurationPageModel model, int value)
    {
        if (model.Id != null)
        {
            ObjectiveProjectionDetailDtoModel? target = objectiveConfigurationPageModel.Projections.FirstOrDefault(item => item.Index == model.Index);

            if (target == null) return true;

            return model.Id == target.Id;
        }

        return !objectiveConfigurationPageModel.Projections.Any(item => item.Index == value);
    }
}