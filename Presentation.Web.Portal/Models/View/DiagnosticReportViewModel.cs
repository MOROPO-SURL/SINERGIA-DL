using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Feature.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritorialBarrier.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritoryPotential.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.Portal.Models.View;

public sealed class DiagnosticReportViewModel
{
    public FeatureDetailDtoModel[] Features { get; set; } = [];

    public ObjectiveDetailDtoModel[] Objectives { get; set; } = [];

    public TerritorialBarrierDetailDtoModel[] TerritorialBarriers { get; set; } = [];

    public TerritoryPotentialDetailDtoModel[] TerritoryPotentials { get; set; } = [];

    public PublicPolicyGroupViewModel[] PublicPolicyGroups { get; set; } = [];
}
