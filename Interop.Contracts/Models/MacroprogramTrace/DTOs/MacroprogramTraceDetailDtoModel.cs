using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.MacroprogramTrace.DTOs;

public record MacroprogramTraceDetailDtoModel(long Id, TraceKind Kind, DateTime CreatedAt, string Author, string? BeforeData = null, string? AfterData = null);