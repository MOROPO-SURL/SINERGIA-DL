using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters
{
    public sealed class ImagePickPresenter
    {
        private static ImagePickPresenter? instance;

        public static ImagePickPresenter Instance
        {
            get
            {
                instance ??= new ImagePickPresenter();

                return instance;
            }
        }

        private Models.Page.Bases.BasePageModel? pageBindingContext;
        private IDispatcher? dispatcher;
        private Action<ImageCreateRequestModel>? successCallbackAction;

        public async void BeginImagePickAsync(Page page, Action<ImageCreateRequestModel> successCallbackAction)
        {
            pageBindingContext = (Models.Page.Bases.BasePageModel)page.BindingContext;

            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                var permission = await Permissions.CheckStatusAsync<Permissions.Photos>();

                if (permission != PermissionStatus.Granted)
                {
                    permission = await Permissions.RequestAsync<Permissions.Photos>();
                }

                if (permission != PermissionStatus.Granted)
                {
                    page.Dispatcher.Dispatch(() =>
                    {
                        page.DisplayAlert("Aviso", string.Format("El permiso para acceder a las fotos del dispositivo es necesario para esta funcionalidad.{0}{0}Deberá permitir el acceso en los ajustes del sistema para la aplicación.", Environment.NewLine), "Aceptar");

                        pageBindingContext.IsBusy = false;
                        pageBindingContext.BusyProgressMessage = string.Empty;

                        pageBindingContext = null;
                    });

                    return;
                }
            }
            else
            {
                var permission = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

                if (permission != PermissionStatus.Granted)
                {
                    permission = await Permissions.RequestAsync<Permissions.StorageRead>();
                }

                if (permission != PermissionStatus.Granted)
                {
                    page.Dispatcher.Dispatch(() =>
                    {
                        page.DisplayAlert("Aviso", string.Format("El permiso para acceder a las fotos del dispositivo es necesario para esta funcionalidad.{0}{0}Deberá permitir el acceso en los ajustes del sistema para la aplicación.", Environment.NewLine), "Aceptar");

                        pageBindingContext.IsBusy = false;
                        pageBindingContext.BusyProgressMessage = string.Empty;

                        pageBindingContext = null;
                    });

                    return;
                }
            }

            page.Dispatcher.Dispatch(() =>
            {
                pageBindingContext.IsBusy = true;
                pageBindingContext.BusyProgressMessage = "Seleccionando imagen ...";
            });

            dispatcher = page.Dispatcher;

            this.successCallbackAction = successCallbackAction;

            await MediaPicker.PickPhotoAsync().ContinueWith(PickedImageContinuationTask!);
        }

        private async Task PickedImageContinuationTask(Task<FileResult> task)
        {
            if (task.Result == null)
            {
                dispatcher!.Dispatch(() =>
                {
                    pageBindingContext!.IsBusy = false;
                    pageBindingContext.BusyProgressMessage = string.Empty;
                });

                return;
            }

            ImageCreateRequestModel result;

            using (Stream imageFileStream = await task.Result.OpenReadAsync())
            {
                using MemoryStream bufferMemomryStream = new((int)imageFileStream.Length);

                result = new ImageCreateRequestModel(Guid.NewGuid(), bufferMemomryStream.ToArray(), task.Result.ContentType);
            }

            pageBindingContext!.IsBusy = false;
            pageBindingContext.BusyProgressMessage = string.Empty;

            successCallbackAction?.Invoke(result);

            pageBindingContext = null;
            dispatcher = null;
            successCallbackAction = null;
        }
    }
}
