using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Location;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n;

public partial class LocationPickPage :
    BaseListEntityPage<LocationDetailDtoModel, LocationPickPageModel>,
    IListItemsPageModelPresenter<LocationDetailDtoModel>
{
    public LocationPickPage(Action<LocationDetailDtoModel> pickedCallbackAction, Action<LocationUpdateRequestModel> createRequiredCallbackAction) : base(new LocationPickPageModel(pickedCallbackAction, createRequiredCallbackAction))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemDetailUserInterfaceAsync(LocationDetailDtoModel model)
    {
        throw new NotImplementedException();
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Terminal.Common.Constants.CardViewSizeConstants.LOCATION_DEFAULT_CARD_VIEW_HEIGHT;

    protected void CancelToolbarItem_Clicked(object sender, EventArgs eventArgs)
    {
        (Parent as NavigationPage)!.NavigationPopModalPageAsync();
    }
}