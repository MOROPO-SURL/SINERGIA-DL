namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

public interface IListItemsPageModelPresenter<TBasicModel>
{
    public Task PresentItemDetailUserInterfaceAsync(TBasicModel model);

    public int CalculatecurrentItemsPageLimit();
}
