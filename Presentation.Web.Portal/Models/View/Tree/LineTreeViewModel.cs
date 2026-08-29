using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Models.View.Tree;

public record LineTreeViewModel(StrategicLineDetailDtoModel Line, ProgramTreeViewModel[] ProgramTrees);
