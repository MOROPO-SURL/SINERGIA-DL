using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.SocialResponsabilityAction;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.UI.Pages.SocialResponsabilityAction;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.UI.Pages;

public partial class SocialResponsabilityActionsManagementPage :
    BaseListEntityPage<SRLSocialResponsabilityActionBasicDtoModel, SocialResponsabilityActionsManagementPageModel>,
    IListItemsPageModelPresenter<SRLSocialResponsabilityActionBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
    public SocialResponsabilityActionsManagementPage() : base(new SocialResponsabilityActionsManagementPageModel())
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<SRLSocialResponsabilityActionBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemCreateUserInterfaceAsync()
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new SocialResponsabilityActionConfigurationPage(new SocialResponsabilityActionConfigurationPageModel(((Common.Models.Page.AppShellPageModel)((Shells.AppShell)Application.Current!.MainPage!).BindingContext).DevelopmentProfileId!.Value, null, _ => ConcreteBindingContext.LoadItems(true), new Validators.SocialResponsabilityActionConfigurationValidator()))));

        return Task.CompletedTask;
    }

    public async Task PresentItemDetailUserInterfaceAsync(SRLSocialResponsabilityActionBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        SRLSocialResponsabilityActionQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        SRLSocialResponsabilityActionDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new SocialResponsabilityActionDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Common.Constants.CardViewSizeConstants.SOCIALRESPONSABILITYACTION_DEFAULT_CARD_VIEW_HEIGHT;
}