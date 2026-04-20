using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages;

public partial class SettingPage : ContentPage
{
	private readonly Action settingChangeCallbackAction;

    public SettingPage(Action settingChangeCallbackAction)
	{
		InitializeComponent();

		this.settingChangeCallbackAction = settingChangeCallbackAction;

		BindingContext = new Models.Page.SettingPageModel(ApplySuccess_Callback, Validation_Callback);
	}

    private void ApplySuccess_Callback()
	{
        settingChangeCallbackAction?.Invoke();

        this.NavigationPopModalPageAsync();
    }

    private void Validation_Callback()
	{
		var concreteBindingContext = (Models.Page.SettingPageModel)BindingContext;

		if (concreteBindingContext.ValidationResult == null || concreteBindingContext.ValidationResult.IsValid) return;

        DisplayAlert("Aviso", "La información especificada no es válida para aplicar los cambios en el sistema.", "Aceptar");
    }

    protected void DismissControl_Invoked(object sender, EventArgs eventArgs)
    {
        this.NavigationPopModalPageAsync();
    }
}