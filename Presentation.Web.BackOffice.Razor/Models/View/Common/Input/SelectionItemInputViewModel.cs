namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Common.Input;

public class SelectionItemInputViewModel<TId>
{
    public bool Selected { get; set; }

    public TId Id { get; set; } = default!;

    public string Label { get; set; } = null!;
}
