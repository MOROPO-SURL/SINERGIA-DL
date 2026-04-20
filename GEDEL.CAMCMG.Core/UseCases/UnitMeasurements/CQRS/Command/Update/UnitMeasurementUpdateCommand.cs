using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Command.Update;

public record UnitMeasurementUpdateCommand (Guid Id, string Name, string Symbol, bool Prefixed, bool IsEnable): IUpdateCommand<Guid, DTOs.UnitMeasurementDetailDto>;

