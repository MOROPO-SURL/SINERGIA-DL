using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Bases;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

public interface IListItemsPageModelPresenter<TBasicModel>
{
    public Task PresentItemDetailUserInterfaceAsync(TBasicModel model);

    public int CalculatecurrentItemsPageLimit();
}
