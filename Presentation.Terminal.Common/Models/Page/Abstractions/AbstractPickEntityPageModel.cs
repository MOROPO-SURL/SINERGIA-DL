using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

public abstract class AbstractPickEntityPageModel<TModel> : AbstractListEntityPageModel<TModel>
{
    protected readonly Action<TModel> pickedCallbackAction;

    protected AbstractPickEntityPageModel(Action<TModel> pickedCallbackAction) : base()
    {
        this.pickedCallbackAction = pickedCallbackAction;

        DetailItemCommand = new Command<TModel>(model =>
        {
            if (IsBusy) return;

            this.pickedCallbackAction.Invoke(model);

            Application.Current!.MainPage!.NavigationPopModalPageAsync();
        });
    }
}