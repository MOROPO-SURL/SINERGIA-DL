namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.KeyVariableTraces;

public record KeyVariableTraceBasicViewModel(long Id, Domain.Aggretates.TraceAggregate.Enumerations.TraceKind Kind, string Author, DateTime CreatedAt);

