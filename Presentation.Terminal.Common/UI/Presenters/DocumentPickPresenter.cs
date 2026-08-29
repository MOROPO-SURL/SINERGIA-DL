using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Document.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters;

public sealed class DocumentPickPresenter
{
    private static DocumentPickPresenter? instance;

    public static DocumentPickPresenter Instance
    {
        get
        {
            instance ??= new DocumentPickPresenter();

            return instance;
        }
    }

    private Models.Page.Bases.BasePageModel? pageBindingContext;
    private IDispatcher? dispatcher;
    private Action<DocumentCreateRequestModel>? successCallbackAction;

    public async void BeginDocumentPickAsync(Page page, Action<DocumentCreateRequestModel> successCallbackAction)
    {
        pageBindingContext = (Models.Page.Bases.BasePageModel)page.BindingContext;

        var permission = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

        if (permission != PermissionStatus.Granted)
        {
            permission = await Permissions.RequestAsync<Permissions.StorageRead>();
        }

        if (permission != PermissionStatus.Granted)
        {
            page.Dispatcher.Dispatch(() =>
            {
                page.DisplayAlert("Aviso", string.Format("El permiso para acceder a los documentos del dispositivo es necesario para esta funcionalidad.{0}{0}Deberá permitir el acceso en los ajustes del sistema para la aplicación.", Environment.NewLine), "Aceptar");

                pageBindingContext.IsBusy = false;
                pageBindingContext.BusyProgressMessage = string.Empty;

                pageBindingContext = null;
            });

            return;
        }

        page.Dispatcher.Dispatch(() =>
        {
            pageBindingContext.IsBusy = true;
            pageBindingContext.BusyProgressMessage = "Seleccionando archivo ...";
        });

        dispatcher = page.Dispatcher;

        this.successCallbackAction = successCallbackAction;

        await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, [ "public.my.comic.extension" ] }, // UTType values
                    { DevicePlatform.Android, [ "application/comics" ] }, // MIME type
                    { DevicePlatform.WinUI, [ ".doc", ".docx", ".dot", ".pdf", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".png", ".jpg", ".jpeg", ".bmp"] }, // file extension
                    { DevicePlatform.macOS, [ "cbr", "cbz" ] }, // UTType values
                })
        }).ContinueWith(PickedDocumentContinuationTask!);
    }

    private async Task PickedDocumentContinuationTask(Task<FileResult> task)
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

        DocumentCreateRequestModel result;

        using (Stream fileStream = await task.Result.OpenReadAsync())
        {
            byte[] data = new byte[(int)fileStream.Length];

            await fileStream.ReadAsync(data);

            result = new DocumentCreateRequestModel(Guid.NewGuid(), Path.GetFileNameWithoutExtension(task.Result.FileName), data, MimeTypes.MimeTypeMap.GetMimeType(Path.GetExtension(task.Result.FileName)));
        }

        pageBindingContext!.IsBusy = false;
        pageBindingContext.BusyProgressMessage = string.Empty;

        successCallbackAction?.Invoke(result);

        pageBindingContext = null;
        dispatcher = null;
        successCallbackAction = null;
    }
}