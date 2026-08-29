using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectIdea.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Models.View.Tree;

public record ProgramTreeViewModel(StrategicProgramDetailDtoModel Program, StrategicProjectIdeaDetailDtoModel[] Ideas, StrategicProjectDetailDtoModel[] Projects);