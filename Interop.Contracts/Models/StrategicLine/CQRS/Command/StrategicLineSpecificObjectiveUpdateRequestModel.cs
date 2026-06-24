namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;

public record StrategicLineSpecificObjectiveUpdateRequestModel(Guid Id, int Index, string Content);