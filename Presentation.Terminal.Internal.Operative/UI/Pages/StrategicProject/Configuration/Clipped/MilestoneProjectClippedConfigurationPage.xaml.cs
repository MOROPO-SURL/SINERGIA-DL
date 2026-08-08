using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Configuration.Clipped
{
    public partial class MilestoneProjectClippedConfigurationPage : BaseConfigurationEntityPage<IndicatorMilestoneDetailDtoModel, IndicatorMilestoneDetailDtoModel, MilestoneProjectClippedConfigurationPageModel>
    {
        public MilestoneProjectClippedConfigurationPage(MilestoneProjectClippedConfigurationPageModel bindingContextModel) : base(bindingContextModel)
        {
            InitializeComponent();
        }

        protected override string EntityTypeName => "Meta";
    }
}