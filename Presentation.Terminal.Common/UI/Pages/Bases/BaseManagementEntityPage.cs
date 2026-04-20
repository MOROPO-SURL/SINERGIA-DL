using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Manager;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;

public class BaseManagementEntityPage<TBasicModel, TDetailModel, TManagePageModel, TConfigurationPageModel> : BaseListEntityPage<TBasicModel, TDetailModel, TManagePageModel>
    where TManagePageModel : AbstractListEntityPageModel<TBasicModel, TDetailModel>, new()
    where TConfigurationPageModel : AbstractConfigurationPageModel<TDetailModel, TDetailModel>
{
    public BaseManagementEntityPage() : base()
    {
    }

    protected virtual bool ConfigurationRequiredAsyncWorkPresentation => false;

    protected virtual string? CreatorPermissionCode => null;

    protected virtual string? EditorPermissionCode => null;

    protected void CreateControl_Invoked(object sender, EventArgs eventArgs)
    {
        if (CreatorPermissionCode != null)
        {
            var session = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>()!.CurrentSession!;

            if (!session.HasFullAccess && !session.Permissions.Any(item => item == ViewerPermissionCode))
            {
                DisplayAlert("Aviso", "Su usuario no cuenta con permisos para agregar nuevos elementos. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

                return;
            }
        }

        ConcreteBindingContext.IsBusy = ConfigurationRequiredAsyncWorkPresentation;

        BuildConfigurationPageAysnc().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = false;

                if (task.IsFaulted || task.IsCanceled)
                {
                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                }
                else
                {
                    this.NavigationPushPageAsync(task.Result);
                }
            });
        });
    }

    protected virtual Task<BaseConfigurationEntityPage<TBasicModel, TDetailModel, TConfigurationPageModel>> BuildConfigurationPageAysnc(TBasicModel? model = default) => throw new NotImplementedException();
}
