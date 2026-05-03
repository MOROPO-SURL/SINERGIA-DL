using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Macroprogram;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Macroprogram.Configuration;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Macroprogram.Configuration;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Macroprogram.Detail;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class MacroprogramsManagementPage : 
    BaseManagementEntityPage<MacroprogramBasicDtoModel, MacroprogramDetailDtoModel, MacroprogramsManagementPageModel, MacroprogramConfigurationPageModel>, 
    IListItemsPageModelPresenter<MacroprogramBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
	public MacroprogramsManagementPage()
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<MacroprogramBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemCreateUserInterfaceAsync()
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new MacroprogramConfigurationPage(new MacroprogramConfigurationPageModel(null, model => ConcreteBindingContext.LoadItems(true)))));

        return Task.CompletedTask;
    }

    public async Task PresentItemDetailUserInterfaceAsync(MacroprogramBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        MacroprogramQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        MacroprogramDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new MacroprogramDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.MACROPROGRAM_DEFAULT_CARD_VIEW_HEIGHT;
}