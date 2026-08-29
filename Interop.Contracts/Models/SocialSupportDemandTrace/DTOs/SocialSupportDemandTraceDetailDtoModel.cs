using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialSupportDemandTrace.DTOs;

public record SocialSupportDemandTraceDetailDtoModel(long Id, TraceKind Kind, DateTime CreatedAt, string Author, string? BeforeData = null, string? AfterData = null);