namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicLines;

public record StrategicLineDetailViewModel(Guid Id, int Index, int? AxeId, string Name, bool IsArchived, bool IsEnabled, string? Description = null);