using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Helper;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages;

public class BaseConfigurationBaseContentPage<TBasicModel, TDetailModel, TConfigurationPageModel> : BaseContentPage
    where TConfigurationPageModel : AbstractConfigurationPageModel<TBasicModel>
{
    private readonly Action<TDetailModel> successCallbackAction;
    private readonly FluentValidation.AbstractValidator<TConfigurationPageModel> validator;
    protected bool hasChangesFlag;

    public BaseConfigurationBaseContentPage(Action<TDetailModel> successCallbackAction, TConfigurationPageModel bindingContextModel, FluentValidation.AbstractValidator<TConfigurationPageModel> validator)
    {
        this.successCallbackAction = successCallbackAction;
        this.validator = validator;

        if (bindingContextModel.OnEditionMode)
        {
            Title = $"Modificar {EntityTypeName}";
        }
        else
        {
            Title = $"Agregar {EntityTypeName}";
        }

        BindingContext = bindingContextModel;

       ConcreteBindingContext.PropertyChanged += PageModel_PropertyChanged!;
    }

    protected override bool OnBackButtonPressed()
    {
        OnCancel(this, EventArgs.Empty);

        return true;
    }

    protected virtual string EntityTypeName { get; } = "Elemento";

    public TConfigurationPageModel ConcreteBindingContext => (TConfigurationPageModel)BindingContext;

    protected virtual Task<TDetailModel> PerformCreationAsync() => throw new NotImplementedException();

    protected virtual Task<TDetailModel> PerformEditionAsync() => throw new NotImplementedException();

    private void PageModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        hasChangesFlag = true;
    }

    protected void OnApply(object sender, EventArgs eventArgs)
    {
        if (ConcreteBindingContext.OnEditionMode && !hasChangesFlag)
        {
            this.NavigationPopPageAsync();

            return;
        }

        if (validator != null)
        {
            ConcreteBindingContext.ValidationResult = null;

            ConcreteBindingContext.ValidationResult = validator.Validate(ConcreteBindingContext);

            if (!ConcreteBindingContext.ValidationResult.IsValid)
            {
                DisplayAlert("Aviso", "La información especificada no es válida para aplicar los cambios en el sistema.", "Aceptar");

                return;
            }
        }

        ConcreteBindingContext.IsBusy = true;

        var task = ConcreteBindingContext.OnEditionMode ? PerformEditionAsync() : PerformCreationAsync();

        task.ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception == null && !task.IsCanceled)
                {
                    successCallbackAction.Invoke(task.Result);

                    this.NavigationPopPageAsync();
                }
                else
                {
                    ConcreteBindingContext.IsBusy = false;

                    HandleException(task.Exception);
                }
            });
        });
    }

    protected void OnCancel(object sender, EventArgs eventArgs)
    {
        if (!hasChangesFlag)
        {
            this.NavigationPopPageAsync();

            return;
        }

        DisplayAlert("Confirmación", "Está seguro que desea regresar sin guardar los cambios?", "Regresar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() => this.NavigationPopPageAsync());
        });
    }

    protected virtual void HandleException(Exception? exception)
    {
        IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(exception, this);
    }
}
