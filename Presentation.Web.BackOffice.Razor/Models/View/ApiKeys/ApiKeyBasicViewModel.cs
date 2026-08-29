namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.ApiKeys;

public record ApiKeyBasicViewModel(Guid Id, string Name, bool IsEnabled, DateTime ExpireAt);