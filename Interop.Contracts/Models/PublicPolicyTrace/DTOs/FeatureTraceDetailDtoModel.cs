using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicyTrace.DTOs;

public record PublicPolicyTraceDetailDtoModel(long Id, TraceKind Kind, DateTime CreatedAt, string Author, string? BeforeData = null, string? AfterData = null);