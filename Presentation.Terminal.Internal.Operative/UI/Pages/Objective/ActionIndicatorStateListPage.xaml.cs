using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Detail;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective;

public partial class ActionIndicatorStateListPage :
    BaseListEntityPage<ObjectiveIndicatorStateActionGroupedViewModel, ActionIndicatorStateListPageModel>,
    IListItemsPageModelPresenter<ObjectiveIndicatorStateActionGroupedViewModel>
{
    public ActionIndicatorStateListPage(ObjectiveDetailDtoModel model) : base(new ActionIndicatorStateListPageModel(model))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);

        IsEnabled = false;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (IsEnabled) return;

        ConcreteBindingContext.ReloadCommand.Execute(null);

        IsEnabled = true;
    }


    public Task PresentItemDetailUserInterfaceAsync(ObjectiveIndicatorStateActionGroupedViewModel model)
    {
        throw new InvalidOperationException();
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.INDICATOR_STATE_CARD_VIEW_HEIGHT;

    private void AddChangeButton_Clicked(object sender, EventArgs args)
    {
        ObjectiveIndicatorStateViewModel model = (ObjectiveIndicatorStateViewModel)(sender as BindableObject)!.BindingContext;

        this.NavigationPushModalPageAsync(new IndicatorChangeConfigurationPage(new Models.Page.Objective.Configuration.IndicatorChangeConfigurationPageModel(ConcreteBindingContext.Objective.Id, model.ActionId, model.Indicator.Id, model.Indicator.Name, model.Indicator.UnitMeasurement, AddChangeSuccess_Callback, new Validators.ObjectiveActionIndicatorChangeConfigurationValidator())));
    }

    private void DetailLastChangeButton_Clicked(object sender, EventArgs args)
    {
        ObjectiveIndicatorStateViewModel model = (ObjectiveIndicatorStateViewModel)(sender as BindableObject)!.BindingContext;

        this.NavigationPushModalPageAsync(new IndicatorStateDetailPage(model));
    }

    private void AddChangeSuccess_Callback(IndicatorChangeDetailDtoModel model)
    {
        ObjectiveIndicatorStateActionGroupedViewModel groupd = ConcreteBindingContext.Items.Single(item => item.Id == model.ActionId);

        ObjectiveIndicatorStateViewModel item = groupd.Single(_item => _item.Indicator.Id == model.IndicatorId);

        if (item.LastChange?.Id > model.Id) return;

        item.LastChange = model;
    }
}