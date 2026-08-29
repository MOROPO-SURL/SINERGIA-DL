using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.DTOs;

public record StrategicProjectIdeaTraceDetailDto(long Id, TraceKind Kind, DateTime CreatedAt, string Author, string? BeforeData = null, string? AfterData = null) : IDetailDto;