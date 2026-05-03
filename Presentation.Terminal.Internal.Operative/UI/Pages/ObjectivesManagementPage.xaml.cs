using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Configuration;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Detail;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class ObjectivesManagementPage : 
    BaseManagementEntityPage<ObjectiveBasicDtoModel, ObjectiveDetailDtoModel, ObjectivesManagementPageModel, ObjectiveConfigurationPageModel>, 
    IListItemsPageModelPresenter<ObjectiveBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
	public ObjectivesManagementPage()
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<ObjectiveBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemCreateUserInterfaceAsync()
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new ObjectiveConfigurationPage(new ObjectiveConfigurationPageModel(null, model => ConcreteBindingContext.LoadItems(true)))));

        return Task.CompletedTask;
    }

    public async Task PresentItemDetailUserInterfaceAsync(ObjectiveBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        ObjectiveQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        ObjectiveDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new ObjectiveDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.OBJECTIVE_DEFAULT_CARD_VIEW_HEIGHT;
}