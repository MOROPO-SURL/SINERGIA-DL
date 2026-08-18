using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeaTraces.DTOs;

public record StrategicProjectIdeaTraceBasicDto(long Id, TraceKind Kind, DateTime CreatedAt, string Author) : IDto;