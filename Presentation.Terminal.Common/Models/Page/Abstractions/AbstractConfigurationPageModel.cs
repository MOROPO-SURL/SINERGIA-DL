using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.User.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

public abstract class AbstractConfigurationPageModel<TInModel, TOutModel> : BasePageModel, Interfaces.IValidableConfigurationPageModel
{
    private readonly IValidator validator;
    private readonly Action<TOutModel> successCallbackAction;

    private FluentValidation.Results.ValidationResult? validationResult;

    protected bool hasChangesFlag;

    protected AbstractConfigurationPageModel(TInModel? model, Action<TOutModel> successCallbackAction, IValidator validator)
    {
        this.successCallbackAction = successCallbackAction;
        this.validator = validator;

        OnEditionMode = model != null;

        PropertyChanged += PageModel_PropertyChanged!;

        ApplyCommand = new Command(() =>
        {
            if (OnEditionMode && !hasChangesFlag)
            {
                Application.Current!.MainPage!.NavigationPopPageAsync();

                return;
            }

            if (this.validator != null)
            {
                ValidationResult = null;

                ValidationResult = this.validator.Validate(ValidationContext);

                if (!ValidationResult.IsValid)
                {
                    Application.Current!.MainPage!.DisplayAlert("Aviso", "La información especificada no es válida para aplicar los cambios en el sistema.", "Aceptar");

                    return;
                }
            }

            IsBusy = true;

            Task<TOutModel> task = OnEditionMode ? PerformEditionAsync() : PerformCreationAsync();

            task.ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    if (!task.IsFaulted && !task.IsCanceled)
                    {
                        this.successCallbackAction.Invoke(task.Result);

                        Application.Current!.MainPage!.NavigationPopPageAsync().ContinueWith(_task =>
                        {
                            if (!PresentChangeNotification) return;

                            Dispatcher.Dispatch(() => Application.Current!.PresentToastNotification(Enumerations.NotificationKind.Success, "Cambios aplicados con éxito."));
                        });
                    }
                    else
                    {
                        IsBusy = false;

                        HandleException(task.Exception);
                    }
                });
            });
        });

        CancelCommand = new Command(() =>
        {
            if (!hasChangesFlag)
            {
                Application.Current!.MainPage!.NavigationPopPageAsync();

                return;
            }

            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea regresar sin guardar los cambios?", "Regresar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Dispatcher.Dispatch(() => Application.Current!.MainPage!.NavigationPopPageAsync());
            });
        });
    }

    protected override void DisposeUnmanagedResources()
    {
        base.DisposeUnmanagedResources();

        PropertyChanged -= PageModel_PropertyChanged!;

        validationResult = null;
    }

    protected virtual bool PresentChangeNotification => true;

    public bool OnEditionMode { get; private set; }

    public FluentValidation.Results.ValidationResult? ValidationResult { get => validationResult; set => SetProperty(ref validationResult, value); }

    public System.Collections.ObjectModel.ObservableCollection<UserBasicDtoModel> NotificationUsers { get; private set; } = [];

    public ICommand ApplyCommand { get; private set; }

    public ICommand CancelCommand { get; private set; }

    public virtual IValidationContext? ValidationContext => null;

    protected abstract Task<TOutModel> PerformCreationAsync();

    protected abstract Task<TOutModel> PerformEditionAsync();

    private void PageModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        hasChangesFlag = true;
    }

    protected virtual void HandleException(Exception? exception)
    {
        IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(exception);
    }
}