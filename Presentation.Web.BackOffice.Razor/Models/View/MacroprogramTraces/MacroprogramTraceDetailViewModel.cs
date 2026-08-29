namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.MacroprogramTraces;

public record MacroprogramTraceDetailViewModel (long Id, Domain.Aggretates.TraceAggregate.Enumerations.TraceKind Kind, string Author, DateTime CreatedAt, string? BeforeData = null, string? AfterData = null);
