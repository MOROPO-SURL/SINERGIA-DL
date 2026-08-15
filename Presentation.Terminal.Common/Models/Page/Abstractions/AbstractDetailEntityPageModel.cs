using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

public abstract class AbstractDetailEntityPageModel<TModel> : BasePageModel
{
    private readonly Action? changeCallbackAction;
    private TModel model;

    private IDetailItemPageModelPresenter<TModel> presenter = null!;

    protected AbstractDetailEntityPageModel(TModel model, Action? changeCallbackAction = null)
    {
        this.model = model;

        this.changeCallbackAction = changeCallbackAction;

        ModifyCommand = new Command(() =>
        {
            if (EditionPermissionCode != null)
            {
                var session = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>().CurrentSession;

                if (!session!.HasFullAccess && !session.Permissions.Any(item => item == EditionPermissionCode))
                {
                    Application.Current!.MainPage!.DisplayAlert("Aviso", "Su usuario no cuenta con permisos para modificar elementos. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

                    return;
                }
            }

            presenter!.PresentItemModifyUserInterfaceAsync(Model, ConfigurationSuccess_Callback).ContinueWith(task =>
            {
                if (!task.IsFaulted && !task.IsCanceled) return;

                Dispatcher.Dispatch(() =>
                {
                    IsBusy = false;

                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                });
            });
        });

        RemoveCommand = new Command(() =>
        {
            if (RemovePermissionCode != null)
            {
                var session = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>().CurrentSession;

                if (!session!.HasFullAccess && !session.Permissions.Any(item => item == RemovePermissionCode))
                {
                    Application.Current!.MainPage!.DisplayAlert("Aviso", "Su usuario no cuenta con permisos para retirar elementos registrados. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

                    return;
                }
            }

            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                PerformRemotionAsync(Model).ContinueWith(task =>
                {
                    Dispatcher.Dispatch(() =>
                    {
                        if (!task.IsFaulted && !task.IsCanceled)
                        {
                            changeCallbackAction?.Invoke();

                            Application.Current!.MainPage!.NavigationPopPageAsync().ContinueWith(_task =>
                            {
                                if (!PresentChangeNotification) return;

                                Dispatcher.Dispatch(() => Application.Current!.PresentToastNotification(Enumerations.NotificationKind.Success, "Cambios aplicados con éxito."));
                            });
                        }
                        else
                        {
                            IsBusy = false;

                            IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                        }
                    });
                });
            });
        });

    }

    protected virtual bool PresentChangeNotification => true;

    protected virtual string? EditionPermissionCode => null;

    protected virtual string? RemovePermissionCode => null;

    public TModel Model { get => model; set => SetProperty(ref model, value); }

    public ICommand ModifyCommand { get; set; }

    public ICommand RemoveCommand { get; set; }

    public void BindPresenter(IDetailItemPageModelPresenter<TModel> presenter)
    {
        this.presenter = presenter;
    }

    protected abstract Task PerformRemotionAsync(TModel model);

    protected void ConfigurationSuccess_Callback(TModel model)
    {
        Model = model;

        changeCallbackAction?.Invoke();

        Application.Current!.PresentToastNotification(Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");
    }
}
