using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

public abstract class AbstractPickEntityPageModel<TBasicModel> : AbstractListEntityPageModel<TBasicModel>
{
    private readonly Action<TBasicModel> pickedCallbackAction;

    protected AbstractPickEntityPageModel(Action<TBasicModel> pickedCallbackAction) : base()
    {
        this.pickedCallbackAction = pickedCallbackAction;

        DetailItemCommand = new Command<TBasicModel>(model =>
        {
            if (IsBusy) return;

            this.pickedCallbackAction.Invoke(model);

            Application.Current!.MainPage!.NavigationPopModalPageAsync();
        });
    }
}