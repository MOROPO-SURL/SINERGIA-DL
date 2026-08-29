using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectIdeaTrace.DTOs;

public record StrategicProjectIdeaTraceDetailDtoModel(long Id, TraceKind Kind, DateTime CreatedAt, string Author, string? BeforeData = null, string? AfterData = null);