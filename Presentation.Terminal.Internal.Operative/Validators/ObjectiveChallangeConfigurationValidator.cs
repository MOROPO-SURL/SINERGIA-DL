using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Configuration;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class ObjectiveChallangeConfigurationValidator : AbstractValidator<ObjectiveChallengeConfigurationPageModel>
{
    private readonly ObjectiveConfigurationPageModel objectiveConfigurationPageModel;

    public ObjectiveChallangeConfigurationValidator(ObjectiveConfigurationPageModel objectiveConfigurationPageModel)
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

    private bool HasValidIndex(ObjectiveChallengeConfigurationPageModel model, int value)
    {
        if (model.Id != null)
        {
            ObjectiveChallengeDetailDtoModel? target = objectiveConfigurationPageModel.Challanges.FirstOrDefault(item => item.Index == model.Index);

            if (target == null) return true;

            return model.Id == target.Id;
        }

        return !objectiveConfigurationPageModel.Challanges.Any(item => item.Index == value);
    }
}