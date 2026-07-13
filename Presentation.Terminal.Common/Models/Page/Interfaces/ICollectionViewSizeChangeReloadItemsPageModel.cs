using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Interfaces;

internal interface ICollectionViewSizeChangeReloadItemsPageModel
{
    public ICommand ReloadCommand { get; }
}
