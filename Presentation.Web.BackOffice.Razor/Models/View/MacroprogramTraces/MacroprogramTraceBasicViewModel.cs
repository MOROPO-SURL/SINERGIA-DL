namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.MacroprogramTraces;

public record MacroprogramTraceBasicViewModel (long Id, Domain.Aggretates.TraceAggregate.Enumerations.TraceKind Kind, string Author, DateTime CreatedAt);

