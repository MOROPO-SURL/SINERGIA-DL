using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Manager;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

public abstract class AbstractManagementEntityPageModel<TBasicModel, TDetailModel> : AbstractListEntityPageModel<TBasicModel, TDetailModel>
{
    protected virtual bool ConfigurationRequiredAsyncWorkPresentation => false;

    protected virtual string? CreatorPermissionCode => null;

    private IManagementItemsPageModelPresenter presenter = null!;

    protected AbstractManagementEntityPageModel() : base()
    {
        CreateCommand = new Command(() =>
        {
            if (CreatorPermissionCode != null)
            {
                var session = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>().CurrentSession;

                if (!session!.HasFullAccess && !session.Permissions.Any(item => item == CreatorPermissionCode))
                {
                    Application.Current!.MainPage!.DisplayAlert("Aviso", "Su usuario no cuenta con permisos para agregar nuevos elementos. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

                    return;
                }
            }

            IsBusy = ConfigurationRequiredAsyncWorkPresentation;

            presenter!.PresentItemCreateUserInterfaceAsync().ContinueWith(task =>
            {
                if (!task.IsFaulted && !task.IsCanceled) return;

                Dispatcher.Dispatch(() =>
                {
                    IsBusy = false;

                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                });
            });
        });
    }

    public void BindPresenter(IManagementItemsPageModelPresenter presenter)
    {
        this.presenter = presenter;
    }

    public ICommand CreateCommand { get; private set; }
}
