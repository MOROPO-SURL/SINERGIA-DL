using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Ports.Adapter.Helper
{
    public class ExceptionHandlingHelperPortAdapter : IExceptionHandlingHelperPort
    {
        private const string SUPPORT_ORIENTATION_MESSAGE = "Por favor contacte con el personal de asistencia técnica para notificar esta situación.";

        public const string INVALID_CREDENTIALS_LDAP_EXCEPTION_MESSAGE = "Usuario y/o contraseña incorrectos.";

        public static string UPGRADE_REQUIRED_EXCEPTION_MESSAGE = string.Format("Es necearia la actualización de esta aplicación para poder continuar.{1}{1}{0}", SUPPORT_ORIENTATION_MESSAGE, Environment.NewLine);

        public static string UNSPECTED_API_RESPONSE_EXCEPTION_MESSAGE = string.Format("Respuesta del proveedor del sistema no esperada.{1}{1}{0}", SUPPORT_ORIENTATION_MESSAGE, Environment.NewLine);

        public static string NETWORK_EXCEPTION_MESSAGE = string.Format("Error de comunicación con el proveedor del sistema.{1}{1}{0}", SUPPORT_ORIENTATION_MESSAGE, Environment.NewLine);

        public static string TASK_CANCELED_EXCEPTION_MESSAGE = string.Format("El sistema ha tardado demasiado tiempo en responder.{1}{1}{0}", SUPPORT_ORIENTATION_MESSAGE, Environment.NewLine);

        public static string UNSPECTED_EXCEPTION_MESSAGE = string.Format("Error no esperado en el sistema.{1}{1}{0}", SUPPORT_ORIENTATION_MESSAGE, Environment.NewLine);

        public const string ADVICE_ALERT_DIALOG_TITLE = "Aviso";

        public const string CONFIRMATION_ALERT_DIALOG_TITLE = "Confirmar";

        public const string MALE_NONE_OPTION = "Ninguno";

        public const string OK_ACTION = "Aceptar";

        public const string CANCEL_ACTION = "Cancelar";

        public void HandleException(Exception? exception, Action<Exception?>? callbackAction = null)
        {
            if (exception == null)
            {
                Application.Current!.MainPage!.DisplayAlert(ADVICE_ALERT_DIALOG_TITLE, TASK_CANCELED_EXCEPTION_MESSAGE, OK_ACTION).ContinueWith(_ => { callbackAction?.Invoke(exception); });

                return;
            }

            if (exception.InnerException is HttpRequestException httpRequestException)
            {
                if (httpRequestException != null)
                {
                    if (httpRequestException.StatusCode == System.Net.HttpStatusCode.UpgradeRequired)
                    {
                        Application.Current!.MainPage!.DisplayAlert(ADVICE_ALERT_DIALOG_TITLE, UPGRADE_REQUIRED_EXCEPTION_MESSAGE, OK_ACTION).ContinueWith(_ => { callbackAction?.Invoke(exception); });

                        return;
                    }
                    if (httpRequestException.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        Application.Current!.MainPage!.DisplayAlert(ADVICE_ALERT_DIALOG_TITLE, "Su sesión a caducado por tiempo de inactividad. Se le solicitará inicio de sesión nuevamente", OK_ACTION).ContinueWith(async _ =>
                        {
                            ISessionManagerPort sessionManager = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>();

                            await sessionManager.SignOutAsync();

                            Application.Current!.MainPage!.Dispatcher.Dispatch(() => Application.Current!.MainPage!.NavigationPushModalPageAsync(new UI.Pages.UserAuthenticationPage()));
                        });

                        return;
                    }
                    if (httpRequestException.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    {
                        Application.Current!.MainPage!.DisplayAlert(ADVICE_ALERT_DIALOG_TITLE, $"Su usuario no cuenta con los permisos requeridos para realizar la operación solicitada.{Environment.NewLine}{Environment.NewLine}{SUPPORT_ORIENTATION_MESSAGE}", OK_ACTION).ContinueWith(_ => { callbackAction?.Invoke(exception); });

                        return;
                    }

#if DEBUG
                    Application.Current!.MainPage!.DisplayAlert(ADVICE_ALERT_DIALOG_TITLE, string.Format("Respuesta del proveedor del sistema no esperada.{1}{1}Código del error: {2}{1}{1}{0}", SUPPORT_ORIENTATION_MESSAGE, Environment.NewLine, httpRequestException.StatusCode), OK_ACTION).ContinueWith(_ => { callbackAction?.Invoke(exception); });
#else
                    Application.Current!.MainPage!.DisplayAlert(ADVICE_ALERT_DIALOG_TITLE, UNSPECTED_API_RESPONSE_EXCEPTION_MESSAGE, OK_ACTION).ContinueWith(_ => { callbackAction?.Invoke(exception); });
#endif

                    return;
                }
            }
            else if (exception.InnerException?.InnerException is System.Net.Sockets.SocketException)
            {
                Application.Current!.MainPage!.DisplayAlert(ADVICE_ALERT_DIALOG_TITLE, NETWORK_EXCEPTION_MESSAGE, OK_ACTION).ContinueWith(_ => { callbackAction?.Invoke(exception); });
            }
            else
            {
                Application.Current!.MainPage!.DisplayAlert(ADVICE_ALERT_DIALOG_TITLE, UNSPECTED_EXCEPTION_MESSAGE, OK_ACTION).ContinueWith(_ => { callbackAction?.Invoke(exception); });
            }
            // TODO Handle native exceptions
            //else
            //{
            //    var nativeMessage = Xamarin.Forms.DependencyService.Get<IApplicationManagerFacade>().GetUnhandleExceptionMessage(targetException);

            //    if (nativeMessage != null) message = nativeMessage;
            //}
        }
    }
}
