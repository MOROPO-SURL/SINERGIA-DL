using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class StrategicProjectListForIndicatorsPage :
    BaseListEntityPage<StrategicProjectBasicDtoModel, StrategicProjectListForIndicatorsPageModel>,
    IListItemsPageModelPresenter<StrategicProjectBasicDtoModel>
{
    public StrategicProjectListForIndicatorsPage() : base(new StrategicProjectListForIndicatorsPageModel())
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemDetailUserInterfaceAsync(StrategicProjectBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        // TODO doit !!!
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.STRATEGICPROJECT_DEFAULT_CARD_VIEW_HEIGHT;
}