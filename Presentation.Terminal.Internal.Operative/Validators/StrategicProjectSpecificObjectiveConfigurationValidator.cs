using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class StrategicProjectSpecificObjectiveConfigurationValidator : AbstractValidator<SpecificObjectiveProjectClippedConfigurationPageModel>
{
    private readonly StrategicProjectConfigurationPageModel configurationPageModel;

    public StrategicProjectSpecificObjectiveConfigurationValidator(StrategicProjectConfigurationPageModel configurationPageModel)
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

    private bool HasValidIndex(SpecificObjectiveProjectClippedConfigurationPageModel model, int value)
    {
        if (model.Id != null)
        {
            SpecificObjectiveProjectDetailDtoModel? target = configurationPageModel.SpecificObjectives.FirstOrDefault(item => item.Index == model.Index);

            if (target == null) return true;

            return model.Id == target.Id;
        }
        
        return !configurationPageModel.SpecificObjectives.Any(item => item.Index == value);
    }
}
