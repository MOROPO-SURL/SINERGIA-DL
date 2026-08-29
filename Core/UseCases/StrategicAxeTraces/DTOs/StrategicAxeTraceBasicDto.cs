using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxeTraces.DTOs
{
    public record StrategicAxeTraceBasicDto(long Id, TraceKind Kind, DateTime CreatedAt, string Author) : IDto;
   
}