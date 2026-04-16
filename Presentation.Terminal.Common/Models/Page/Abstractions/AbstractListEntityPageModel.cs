using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Bases;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

public abstract class AbstractListEntityPageModel<TModel> : BasePageModel
{
    private bool hasMoreItems;
    private string? searchParameter;

    public System.Collections.ObjectModel.ObservableCollection<TModel> Items { get; set; } = [];

    public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

    public string? SearchParameter { get => searchParameter; set => SetProperty(ref searchParameter, value); }
}