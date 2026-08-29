using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Detail;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject;

public partial class IndicatorStateListPage :
    BaseListEntityPage<StrategicProjectIndicatorStateViewModel, IndicatorStateListPageModel>,
    IListItemsPageModelPresenter<StrategicProjectIndicatorStateViewModel>
{
    public IndicatorStateListPage(StrategicProjectDetailDtoModel program) : base(new IndicatorStateListPageModel(program))
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


    public Task PresentItemDetailUserInterfaceAsync(StrategicProjectIndicatorStateViewModel model)
    {
        throw new InvalidOperationException();
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.INDICATOR_STATE_CARD_VIEW_HEIGHT;

    private void AddChangeButton_Clicked(object sender, EventArgs args)
    {
        StrategicProjectIndicatorStateViewModel model = (StrategicProjectIndicatorStateViewModel)(sender as BindableObject)!.BindingContext;

        this.NavigationPushModalPageAsync(new IndicatorChangeConfigurationPage(new Models.Page.StrategicProject.Configuration.IndicatorChangeConfigurationPageModel(ConcreteBindingContext.Project.Id, model.Indicator.Id, model.Indicator.Name, model.Indicator.UnitMeasurement, AddChangeSuccess_Callback, new Validators.StrategicProjectIndicatorChangeConfigurationValidator())));
    }

    private void DetailLastChangeButton_Clicked(object sender, EventArgs args)
    {
        StrategicProjectIndicatorStateViewModel model = (StrategicProjectIndicatorStateViewModel)(sender as BindableObject)!.BindingContext;

        this.NavigationPushModalPageAsync(new IndicatorStateDetailPage(model));
    }

    private void AddChangeSuccess_Callback(IndicatorChangeDetailDtoModel model)
    {
        StrategicProjectIndicatorStateViewModel item = ConcreteBindingContext.Items.Single(item => item.Indicator.Id == model.IndicatorId);

        if (item.LastChange?.Id > model.Id) return;

        item.LastChange = model;
    }
}