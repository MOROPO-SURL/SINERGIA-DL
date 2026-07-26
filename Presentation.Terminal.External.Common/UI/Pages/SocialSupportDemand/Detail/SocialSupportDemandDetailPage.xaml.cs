using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page.SocialSupportDemand.Detail;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.UI.Pages.SocialSupportDemand.Detail;

public partial class SocialSupportDemandDetailPage : BaseDetailEntityPage<SocialSupportDemandDetailDtoModel, SocialSupportDemandDetailPageModel>, IDetailItemPageModelPresenter<SocialSupportDemandDetailDtoModel>
{
    public SocialSupportDemandDetailPage(SocialSupportDemandDetailDtoModel model) : base(new SocialSupportDemandDetailPageModel(model))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemModifyUserInterfaceAsync(SocialSupportDemandDetailDtoModel model, Action<SocialSupportDemandDetailDtoModel> configurationSuccessCallbackAction)
    {
        throw new NotImplementedException();
    }
}