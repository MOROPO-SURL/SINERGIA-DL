using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Command.Create;

public record UnitMeasurementCreateCommand(string Name, string Symbol, bool Prefixed, bool IsEnabled, int Priority) : ICreateCommand<UnitMeasurementDetailDto>;