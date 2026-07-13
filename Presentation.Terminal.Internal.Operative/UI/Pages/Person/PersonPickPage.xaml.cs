using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Person;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Person;

public partial class PersonPickPage :
    BaseListEntityPage<PersonBasicDtoModel, PersonPickPageModel>,
    IListItemsPageModelPresenter<PersonBasicDtoModel>
{
    public PersonPickPage(Action<PersonBasicDtoModel> pickedCallbackAction) : base(new PersonPickPageModel(pickedCallbackAction))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemDetailUserInterfaceAsync(PersonBasicDtoModel model)
    {
        throw new NotImplementedException();
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Common.Constants.CardViewSizeConstants.PERSON_DEFAULT_CARD_VIEW_HEIGHT;

    protected void CancelToolbarItem_Clicked(object sender, EventArgs eventArgs)
    {
        (Parent as NavigationPage)!.NavigationPopModalPageAsync();
    }
}