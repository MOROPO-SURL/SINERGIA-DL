using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Manager;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Validators;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page;

public class UserAuthenticationPageModel : BasePageModel, Interfaces.IValidableConfigurationPageModel
{
    public static string UserNameValidableProperty => nameof(UserName);
    public static string PasswordValidableProperty => nameof(Password);


    private string? userName;
    private string? password;
    private FluentValidation.Results.ValidationResult? validationResult;

    public UserAuthenticationPageModel()
    {
        ApplyCommand = new Command(
            execute: () =>
            {
                UserAuthenticationValidator validator = new();

                ValidationResult = null;
                ValidationResult = validator.Validate(this);

                if (!ValidationResult.IsValid) return;

                IsBusy = true;

                IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>().SignInAsync(UserName!, Password!).ContinueWith(task =>
                {
                    Application.Current!.Dispatcher.Dispatch(() =>
                    {
                        if (task.IsCanceled || task.Exception != null)
                        {
                            var message = "Problemas no esperados en el sistema.";

                            if (task.Exception == null)
                            {
                                message = "El sistema ha tardado demasiado tiempo en responder.";
                            }
                            else
                            {
                                Exception targetException = task.Exception;

                                while (targetException is AggregateException)
                                {
                                    targetException = targetException.InnerException!;
                                }

                                if (targetException is HttpRequestException || targetException is System.Net.WebException)
                                {
                                    message = "No se puede acceder al servidor. Revise su conexión de red y/o la disponibilidad del servicio.";
                                }
                                //else if (targetException is Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException)
                                //{
                                //    var unspectedHttpStatus = (targetException as Framework.Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException).HttpStatusCode;

                                //    if (unspectedHttpStatus == System.Net.HttpStatusCode.BadRequest)
                                //    {
                                //        message = "Datos incorrectos.";
                                //    }
                                //    else if (unspectedHttpStatus == System.Net.HttpStatusCode.Forbidden)
                                //    {
                                //        message = "Usuario no autorizado.";
                                //    }
                                //    else if (unspectedHttpStatus == System.Net.HttpStatusCode.Unauthorized)
                                //    {
                                //        message = "Usuario y/o contraseña incorrectos.";
                                //    }
                                //    else if (unspectedHttpStatus == System.Net.HttpStatusCode.ServiceUnavailable)
                                //    {
                                //        message = "Servicio no disponible en este momento.";
                                //    }
                                //}
                            }

                            IsBusy = false;

                            Application.Current!.MainPage!.DisplayAlert("Error", message, "Aceptar");

                            return;
                        }

                        Application.Current!.MainPage!.NavigationPopModalPageAsync();
                    });
                });
            }
        );
    }

    public System.Windows.Input.ICommand ApplyCommand { get; private set; }

    public string? UserName
    {
        get => userName;
        set => SetProperty(ref userName, value);
    }

    public string? Password
    {
        get => password;
        set => SetProperty(ref password, value);
    }

    public FluentValidation.Results.ValidationResult? ValidationResult 
    { 
        get => validationResult; 
        set => SetProperty(ref validationResult, value, () =>
        {
            if (ValidationResult == null || ValidationResult.IsValid) return;

            Application.Current!.MainPage!.DisplayAlert("Aviso", "La información especificada no es válida para aplicar los cambios en el sistema.", "Aceptar");
        }); 
    }
}
