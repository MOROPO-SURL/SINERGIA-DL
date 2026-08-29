using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Create;

public record UnitMeasurementCreateCommand(string Name, string Symbol, bool Prefixed, bool IsEnabled, int Priority) : ICreateCommand<UnitMeasurementDetailDto>;