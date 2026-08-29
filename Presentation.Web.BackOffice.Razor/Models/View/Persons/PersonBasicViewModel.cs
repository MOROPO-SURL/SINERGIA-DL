namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Persons;

public record PersonBasicViewModel(Guid Id, string Name, bool IsArchived, bool IsEnabled, string? LastName = null);