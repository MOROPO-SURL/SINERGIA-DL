namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Interfaces;

public interface IValidableConfigurationPageModel
{
    public FluentValidation.Results.ValidationResult? ValidationResult { get; }
}
