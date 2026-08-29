namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicLines;

public record StrategicLineBasicViewModel(Guid Id, int Index, int? AxeId, string Name, bool IsArchived, bool IsEnabled);