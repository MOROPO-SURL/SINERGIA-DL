namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Users;

public record UserBasicViewModel(string Id, string Name, DateTime CreatedAt, bool IsIntegrityAssured, bool IsEnabled, bool HasFullAccess, bool IsArchived, string? LastName);
