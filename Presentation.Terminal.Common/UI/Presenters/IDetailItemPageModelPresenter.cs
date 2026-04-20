namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters;

public interface IDetailItemPageModelPresenter<TModel>
{
    public Task PresentItemModifyUserInterfaceAsync(TModel model, Action<TModel> configurationSuccessCallbackAction);
}