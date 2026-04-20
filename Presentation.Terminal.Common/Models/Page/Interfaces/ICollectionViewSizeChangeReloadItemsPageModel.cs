using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Interfaces;

internal interface ICollectionViewSizeChangeReloadItemsPageModel
{
    public ICommand ReloadCommand { get; }
}
