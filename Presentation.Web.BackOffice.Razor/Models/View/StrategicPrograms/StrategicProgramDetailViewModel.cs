namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicPrograms;

public record StrategicProgramDetailViewModel(Guid Id, string Name, bool IsArchived, bool IsEnabled, string? Description = null);