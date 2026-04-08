using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.User.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

public abstract class AbstractConfigurationPageModel<TModel> : BasePageModel
{
    private FluentValidation.Results.ValidationResult? validationResult;

    protected AbstractConfigurationPageModel(TModel? model)
    {
        OnEditionMode = model != null;
    }

    public bool OnEditionMode { get; private set; }

    public FluentValidation.Results.ValidationResult? ValidationResult { get => validationResult; set => SetProperty(ref validationResult, value); }

    public System.Collections.ObjectModel.ObservableCollection<UserBasicModel> NotificationUsers { get; private set; } = [];
}