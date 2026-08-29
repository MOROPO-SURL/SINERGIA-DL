namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.OrganizationKindTraces
{
    public record OrganizationKindTraceBasicViewModel (long Id, Domain.Aggretates.TraceAggregate.Enumerations.TraceKind Kind, string Author, DateTime CreatedAt);
}
