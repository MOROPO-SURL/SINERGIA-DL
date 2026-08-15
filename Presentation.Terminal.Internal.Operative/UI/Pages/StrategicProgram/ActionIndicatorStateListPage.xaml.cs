using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Detail;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram;

public partial class ActionIndicatorStateListPage :
    BaseListEntityPage<StrategicProgramIndicatorStateActionGroupedViewModel, ActionIndicatorStateListPageModel>,
    IListItemsPageModelPresenter<StrategicProgramIndicatorStateActionGroupedViewModel>
{
    public ActionIndicatorStateListPage(StrategicProgramDetailDtoModel program) : base(new ActionIndicatorStateListPageModel(program))
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


    public Task PresentItemDetailUserInterfaceAsync(StrategicProgramIndicatorStateActionGroupedViewModel model)
    {
        throw new InvalidOperationException();
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.INDICATOR_STATE_CARD_VIEW_HEIGHT;

    private void AddChangeButton_Clicked(object sender, EventArgs args)
    {
        StrategicProgramIndicatorStateViewModel model = (StrategicProgramIndicatorStateViewModel)(sender as BindableObject)!.BindingContext;

        this.NavigationPushModalPageAsync(new IndicatorChangeConfigurationPage(new Models.Page.StrategicProgram.Configuration.IndicatorChangeConfigurationPageModel(ConcreteBindingContext.Program.Id, model.ActionId, model.Indicator.Id, model.Indicator.Name, model.Indicator.UnitMeasurement, AddChangeSuccess_Callback, new Validators.StrategicProgramActionIndicatorChangeConfigurationValidator())));
    }

    private void DetailLastChangeButton_Clicked(object sender, EventArgs args)
    {
        StrategicProgramIndicatorStateViewModel model = (StrategicProgramIndicatorStateViewModel)(sender as BindableObject)!.BindingContext;

        this.NavigationPushModalPageAsync(new IndicatorStateDetailPage(model));
    }

    private void AddChangeSuccess_Callback(IndicatorChangeDetailDtoModel model)
    {
        StrategicProgramIndicatorStateActionGroupedViewModel groupd = ConcreteBindingContext.Items.Single(item => item.Id == model.ActionId);

        StrategicProgramIndicatorStateViewModel item = groupd.Single(_item => _item.Indicator.Id == model.IndicatorId);

        if (item.LastChange?.Id > model.Id) return;

        item.LastChange = model;
    }
}