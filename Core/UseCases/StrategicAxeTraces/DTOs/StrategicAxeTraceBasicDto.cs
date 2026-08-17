using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxeTraces.DTOs
{
    public record StrategicAxeTraceBasicDto(long Id, TraceKind Kind, DateTime CreatedAt, string Author) : IDto;
   
}