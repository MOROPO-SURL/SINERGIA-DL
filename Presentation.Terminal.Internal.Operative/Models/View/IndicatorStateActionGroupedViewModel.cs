using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using System.Collections.ObjectModel;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

public sealed class IndicatorStateActionGroupedViewModel : ObservableCollection<IndicatorStateViewModel>
{
    public IndicatorStateActionGroupedViewModel(ActionDetailDtoModel action, IEnumerable<IndicatorStateViewModel> items) : base(items)
    {
        Id = action.Id;
        Title = action.Title;
    }

    public Guid Id { get; init; }

    public string Title { get; init; }
}
