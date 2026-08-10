using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using System.Collections.ObjectModel;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

public sealed class ObjectiveIndicatorStateActionGroupedViewModel : ObservableCollection<ObjectiveIndicatorStateViewModel>
{
    public ObjectiveIndicatorStateActionGroupedViewModel(ObjectiveActionDetailDtoModel action, IEnumerable<ObjectiveIndicatorStateViewModel> items) : base(items)
    {
        Id = action.Id;
        Title = action.Title;
    }

    public Guid Id { get; init; }

    public string Title { get; init; }
}