using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Feature.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritorialBarrier.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritoryPotential.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Models.View;

public sealed class DiagnosticReportViewModel
{
    public FeatureDetailDtoModel[] Features { get; set; } = [];

    public ObjectiveDetailDtoModel[] Objectives { get; set; } = [];

    public TerritorialBarrierDetailDtoModel[] TerritorialBarriers { get; set; } = [];

    public TerritoryPotentialDetailDtoModel[] TerritoryPotentials { get; set; } = [];

    public PublicPolicyGroupViewModel[] PublicPolicyGroups { get; set; } = [];
}
