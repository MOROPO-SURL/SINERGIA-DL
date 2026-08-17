using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.Portal.Models.View.Tree;

public record LineTreeViewModel(StrategicLineDetailDtoModel Line, ProgramTreeViewModel[] ProgramTrees);
