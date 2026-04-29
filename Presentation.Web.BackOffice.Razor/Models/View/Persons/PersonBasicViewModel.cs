namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Persons;

public record PersonBasicViewModel(Guid Id, string Name, bool IsArchived, bool IsEnabled, string? LastName = null);