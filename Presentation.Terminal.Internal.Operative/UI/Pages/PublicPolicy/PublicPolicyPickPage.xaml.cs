using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.PublicPolicy;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.PublicPolicy;

public partial class PublicPolicyPickPage :
    BaseListEntityPage<PublicPolicyBasicDtoModel, PublicPolicyPickPageModel>,
    IListItemsPageModelPresenter<PublicPolicyBasicDtoModel>
{
    public PublicPolicyPickPage(Action<PublicPolicyBasicDtoModel> pickedCallbackAction) : base(new PublicPolicyPickPageModel(pickedCallbackAction))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemDetailUserInterfaceAsync(PublicPolicyBasicDtoModel model)
    {
        throw new NotImplementedException();
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.PUBLICPOLICY_DEFAULT_CARD_VIEW_HEIGHT;

    protected void CancelToolbarItem_Clicked(object sender, EventArgs eventArgs)
    {
        (Parent as NavigationPage)!.NavigationPopModalPageAsync();
    }
}