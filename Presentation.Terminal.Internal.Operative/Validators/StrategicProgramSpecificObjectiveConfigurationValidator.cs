using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

internal sealed class StrategicProgramSpecificObjectiveConfigurationValidator : AbstractValidator<SpecificObjectiveClippedConfigurationPageModel>
{
    private readonly StrategicProgramConfigurationPageModel configurationPageModel;

    public StrategicProgramSpecificObjectiveConfigurationValidator(StrategicProgramConfigurationPageModel configurationPageModel)
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

    private bool HasValidIndex(SpecificObjectiveClippedConfigurationPageModel model, int value)
    {
        if (model.Id != null)
        {
            SpecificObjectiveDetailDtoModel? target = configurationPageModel.SpecificObjectives.FirstOrDefault(item => item.Index == model.Index);

            if (target == null) return true;

            return model.Id == target.Id;
        }

        return !configurationPageModel.SpecificObjectives.Any(item => item.Index == value);
    }
}
