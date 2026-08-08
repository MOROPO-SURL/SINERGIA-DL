using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class ObjectiveListForIndicatorsPage :
    BaseListEntityPage<ObjectiveBasicDtoModel, ObjectiveListForIndicatorsPageModel>,
    IListItemsPageModelPresenter<ObjectiveBasicDtoModel>
{
    public ObjectiveListForIndicatorsPage() : base(new ObjectiveListForIndicatorsPageModel())
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemDetailUserInterfaceAsync(ObjectiveBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        // TODO doit !!!
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.OBJECTIVE_DEFAULT_CARD_VIEW_HEIGHT;
}