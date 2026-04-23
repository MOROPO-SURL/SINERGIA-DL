using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritorialBarrier.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.TerritorialBarrier;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.TerritorialBarrier;

public partial class TerritorialBarrierConfigurationPage : BaseConfigurationEntityPage<TerritorialBarrierBasicDtoModel, TerritorialBarrierDetailDtoModel, TerritorialBarrierConfigurationPageModel>
{
    public TerritorialBarrierConfigurationPage(TerritorialBarrierConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Barrera del territorio";
}