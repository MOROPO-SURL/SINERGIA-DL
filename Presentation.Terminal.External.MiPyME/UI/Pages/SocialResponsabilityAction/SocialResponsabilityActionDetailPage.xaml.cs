using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.SocialResponsabilityAction;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Validators;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.UI.Pages.SocialResponsabilityAction;

public partial class SocialResponsabilityActionDetailPage : BaseDetailEntityPage<SRLSocialResponsabilityActionDetailDtoModel, SocialResponsabilityActionDetailPageModel>, IDetailItemPageModelPresenter<SRLSocialResponsabilityActionDetailDtoModel>
{
    public SocialResponsabilityActionDetailPage(SRLSocialResponsabilityActionDetailDtoModel model) : base(new SocialResponsabilityActionDetailPageModel(model))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemModifyUserInterfaceAsync(SRLSocialResponsabilityActionDetailDtoModel model, Action<SRLSocialResponsabilityActionDetailDtoModel> configurationSuccessCallbackAction)
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new SocialResponsabilityActionConfigurationPage(new SocialResponsabilityActionConfigurationPageModel(((AppShellPageModel)((Shells.AppShell)Application.Current!.MainPage!).BindingContext).DevelopmentProfileId!.Value, model, configurationSuccessCallbackAction, new SocialResponsabilityActionConfigurationValidator()))));

        return Task.CompletedTask;
    }
}