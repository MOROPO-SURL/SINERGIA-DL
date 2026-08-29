using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectKind.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;

public record StrategicProjectBasicDtoModel(Guid Id, string Name, StrategicProjectKindBasicDtoModel Kind, string? Description = null);