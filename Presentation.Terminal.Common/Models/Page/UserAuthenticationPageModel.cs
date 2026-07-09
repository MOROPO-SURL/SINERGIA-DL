using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Factories;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Validators;
using System.Net.Sockets;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page;

public class UserAuthenticationPageModel : BasePageModel, Interfaces.IValidableConfigurationPageModel
{
    public static string UserNameValidableProperty => nameof(UserName);
    public static string PasswordValidableProperty => nameof(Password);

    private readonly Action? successCallbackAction;

    private string? userName;
    private string? password;
    private FluentValidation.Results.ValidationResult? validationResult;

    public UserAuthenticationPageModel(Action? successCallbackAction = null)
    {
        this.successCallbackAction = successCallbackAction;

        ApplyCommand = new Command(() =>
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

                            if (targetException is HttpRequestException httpRequestException)
                            {
                                if (httpRequestException.StatusCode == System.Net.HttpStatusCode.BadRequest)
                                {
                                    message = "Datos incorrectos.";
                                }
                                else if (httpRequestException.StatusCode == System.Net.HttpStatusCode.Forbidden)
                                {
                                    message = "Usuario no autorizado.";
                                }
                                else if (httpRequestException.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                {
                                    message = "Usuario y/o contraseña incorrectos.";
                                }
                                else if (httpRequestException.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
                                {
                                    message = "Servicio no disponible en este momento.";
                                }
                            }
                            else if (targetException is SocketException || targetException is System.Net.WebException)
                            {
                                message = "No se puede acceder al servidor. Revise su conexión de red y/o la disponibilidad del servicio.";
                            }
                        }

                        IsBusy = false;

                        Application.Current!.MainPage!.DisplayAlert("Error", message, "Aceptar");

                        return;
                    }

                    Application.Current!.MainPage!.NavigationPopModalPageAsync().ContinueWith(_ =>
                    {
                        FFImageLoading.ImageService.Instance.Configuration.HttpClient = new HttpClient(HttpClientHandlerFactory.Build());

                        if (successCallbackAction == null) return;

                        Dispatcher.Dispatch(successCallbackAction);
                    });
                });
            });
        });
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
