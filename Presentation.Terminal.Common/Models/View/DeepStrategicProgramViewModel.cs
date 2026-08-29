using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectIdea.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.View;

public record DeepStrategicProgramViewModel(StrategicProgramDetailDtoModel Program, IEnumerable<StrategicProjectIdeaDetailDtoModel> Ideas, IEnumerable<StrategicProjectDetailDtoModel> Projects);