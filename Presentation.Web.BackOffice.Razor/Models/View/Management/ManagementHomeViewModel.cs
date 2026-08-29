namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Management
{
    public class ManagementHomeViewModel
    {
        public KeyValuePair<DayOfWeek, long>[] WeekUserActivity { get; set; } = null!;

        public KeyValuePair<int, long>[] MonthUserActivity { get; set; } = null!;

        public KeyValuePair<int, long>[] SemesterUserActivity { get; set; } = null!;

        public Dictionary<string, long> SingleByLastYearUserActivity { get; set; } = null!;
    }
}

