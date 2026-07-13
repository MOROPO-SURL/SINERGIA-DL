namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

public interface IDetailItemPageModelPresenter<TModel>
{
    public Task PresentItemModifyUserInterfaceAsync(TModel model, Action<TModel> configurationSuccessCallbackAction);
}