using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Person;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Person;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class PersonsManagementPage :
    BaseListEntityPage<PersonBasicDtoModel, PersonsManagementPageModel>,
    IListItemsPageModelPresenter<PersonBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
    public PersonsManagementPage() : base(new PersonsManagementPageModel())
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<PersonBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemCreateUserInterfaceAsync()
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new PersonConfigurationPage(new PersonConfigurationPageModel(null, model => ConcreteBindingContext.LoadItems(true)))));

        return Task.CompletedTask;
    }

    public async Task PresentItemDetailUserInterfaceAsync(PersonBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        PersonQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        PersonDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new PersonDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Common.Constants.CardViewSizeConstants.PERSON_DEFAULT_CARD_VIEW_HEIGHT;
}