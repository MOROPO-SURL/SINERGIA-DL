namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Interfaces;

public interface IValidableConfigurationPageModel
{
    public FluentValidation.Results.ValidationResult? ValidationResult { get; }
}
