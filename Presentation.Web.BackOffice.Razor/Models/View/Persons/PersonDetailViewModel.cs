namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Persons;

public record PersonDetailViewModel(Guid Id, string Name, bool IsArchived, bool IsEnabled, int Priority, string? LastName = null, string? Alias = null, string? About = null);