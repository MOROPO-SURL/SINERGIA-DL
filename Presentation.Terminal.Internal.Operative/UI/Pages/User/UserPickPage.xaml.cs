using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.User.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.User;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.User;

public partial class UserPickPage :
    BaseListEntityPage<UserBasicDtoModel, UserPickPageModel>,
    IListItemsPageModelPresenter<UserBasicDtoModel>
{
    public UserPickPage(Action<UserBasicDtoModel> pickedCallbackAction) : base(new UserPickPageModel(pickedCallbackAction))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemDetailUserInterfaceAsync(UserBasicDtoModel model)
    {
        throw new NotImplementedException();
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.USER_DEFAULT_CARD_VIEW_HEIGHT;

    protected void CancelToolbarItem_Clicked(object sender, EventArgs eventArgs)
    {
        (Parent as NavigationPage)!.NavigationPopModalPageAsync();
    }
}