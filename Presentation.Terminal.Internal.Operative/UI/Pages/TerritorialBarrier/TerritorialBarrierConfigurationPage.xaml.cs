using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritorialBarrier.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.TerritorialBarrier;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.TerritorialBarrier;

public partial class TerritorialBarrierConfigurationPage : BaseConfigurationEntityPage<TerritorialBarrierBasicDtoModel, TerritorialBarrierDetailDtoModel, TerritorialBarrierConfigurationPageModel>
{
    public TerritorialBarrierConfigurationPage(TerritorialBarrierConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Barrera del territorio";
}