namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.UserTraces;

public record UserTraceBasicViewModel(long Id, Domain.Aggretates.TraceAggregate.Enumerations.TraceKind Kind, string Author, DateTime CreatedAt);