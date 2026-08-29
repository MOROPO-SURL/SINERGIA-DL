namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.ApiKeyTraces;

public record ApiKeyTraceBasicViewModel(long Id, Domain.Aggretates.TraceAggregate.Enumerations.TraceKind Kind, string Author, DateTime CreatedAt);